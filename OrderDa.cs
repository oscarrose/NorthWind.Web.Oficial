using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using NorthWind.Web.DataAccess;
using NorthWind.Web.DataAccess.Entity;


namespace NorthWind.Web.DataAccess
{
  public  class OrderDa : DaAcces
   {
        public OrderDa(IConfiguration configuration) : base(configuration)
        {

        }

        public Orders GetById(int orderId)
        {
            Orders order = null;

            using (var connection = GetSqlConecction())
            {
                order = connection.QuerySingle<Orders>("SELECT * FROM Orders WHERE OrderId = @orderId", new { orderId });
                order.OrderDetails = connection.Query("SELECT * , p.ProductName, p.UnitPrice FROM [Order Details] od " +
                    "JOIN Products p on od.ProductID = p.ProductID " +
                    "WHERE OrderId = @orderId",
                    new { orderId })
                    .Select(item => new OrderDetail
                    {
                        OrderID = item.OrderID,
                        ProductID = item.ProductID,
                        Discount = item.Discount,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        Product = new Products
                        {
                            ProductID = item.ProductID,
                            ProductName = item.ProductName
                        }

                    }).AsList();

            }

            return order;
        }

        public void Insert(Orders Order)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("Northwind")))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {

                    var commandInsertOrder = connection.CreateCommand();
                    commandInsertOrder.Transaction = transaction;
                    commandInsertOrder.CommandText = "INSERT INTO [dbo].[Orders]([CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry])" +
                        " VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry); SELECT SCOPE_IDENTITY()";
                    commandInsertOrder.Parameters.AddWithValue("@CustomerID", Order.CustomerID);
                    commandInsertOrder.Parameters.AddWithValue("@EmployeeID", Order.EmployeeID);
                    commandInsertOrder.Parameters.AddWithValue("@OrderDate", Order.OrderDate);
                    commandInsertOrder.Parameters.AddWithValue("@RequiredDate", Order.RequiredDate);
                    commandInsertOrder.Parameters.AddWithValue("@ShippedDate", GetDbNullIfNull(Order.ShippedDate));
                    commandInsertOrder.Parameters.AddWithValue("@ShipVia", GetDbNullIfNull(Order.ShipVia));
                    commandInsertOrder.Parameters.AddWithValue("@Freight", GetDbNullIfNull(Order.Freight));
                    commandInsertOrder.Parameters.AddWithValue("@ShipName", GetDbNullIfNull(Order.ShipName));
                    commandInsertOrder.Parameters.AddWithValue("@ShipAddress", GetDbNullIfNull(Order.ShipAddress));
                    commandInsertOrder.Parameters.AddWithValue("@ShipCity", GetDbNullIfNull(Order.ShipCity));
                    commandInsertOrder.Parameters.AddWithValue("@ShipRegion", GetDbNullIfNull(Order.ShipRegion));
                    commandInsertOrder.Parameters.AddWithValue("@ShipPostalCode", GetDbNullIfNull(Order.ShipPostalCode));
                    commandInsertOrder.Parameters.AddWithValue("@ShipCountry", GetDbNullIfNull(Order.ShipCountry));

                    int orderId = Convert.ToInt32(commandInsertOrder.ExecuteScalar());

                    foreach (var item in Order.OrderDetails)
                    {
                        item.OrderID = orderId;
                        InsertDetail(connection, transaction, item);
                    }

                    transaction.Commit(); 

                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 

                    throw new ApplicationException("Error inserting order ",ex);
                }
            };
        }


        public void InsertDetail(OrderDetail item)
        {
            using (var connection = GetSqlConecction())
            {
                connection.Open();

                InsertDetail(connection, null, item);
            }
        }


        private void InsertDetail(SqlConnection connection, SqlTransaction transaction, OrderDetail item)
        {
            var commandInsertDetail = connection.CreateCommand();
            commandInsertDetail.Transaction = transaction;
            commandInsertDetail.CommandText = "INSERT INTO [dbo].[Order Details]([OrderID], [ProductID], [UnitPrice], [Quantity], [Discount])" +
                " VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)";

            commandInsertDetail.Parameters.AddWithValue("@OrderID", item.OrderID);
            commandInsertDetail.Parameters.AddWithValue("@ProductID", item.ProductID);
            commandInsertDetail.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
            commandInsertDetail.Parameters.AddWithValue("@Quantity", item.Quantity);
            commandInsertDetail.Parameters.AddWithValue("@Discount", item.Discount);

            commandInsertDetail.ExecuteNonQuery();
        }
    }
}
