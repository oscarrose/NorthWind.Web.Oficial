using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Northwind.WebUI.Models;
using System.IO;

namespace Northwind.WebUI.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public List<OrdersModel> Orders { get; set; }
        private readonly IConfiguration configuration;

        //public PrivacyModel(ILogger<PrivacyModel> logger)
        //{
        //    _logger = logger;
        //}

        public PrivacyModel( IConfiguration configuration)
        {

            this.configuration = configuration;
        }

        public void OnGet()
        {
         Orders = new List<OrdersModel>();

            var connectionString = configuration.GetConnectionString("Northwind");


            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {

                command.CommandText = "OrderList";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var ordersItem = new OrdersModel();


                    ordersItem.OrderID = (int)dataReader["OrderId"];
                    ordersItem.CustomerID = (string)dataReader["CustomerID"];
                    ordersItem.OrderDate = (DateTime)dataReader["OrderDate"];
                    ordersItem.RequiredDate = Convert.ToDateTime(dataReader["RequiredDate"]);
                    ordersItem.ShipVia = (int)dataReader["ShipVia"];
                    ordersItem.Freight = (decimal)dataReader["Freight"];
                    ordersItem.ShipName = (string)dataReader["ShipName"];
                    ordersItem.ShipAddress = (String)dataReader["ShipAddress"];
                    ordersItem.ShipCity = (string)dataReader["ShipCity"];
                    ordersItem.ShipRegion = Convert.ToString(dataReader["ShipRegion"]);
                    ordersItem.ShipPostalCode = Convert.ToString(dataReader["ShipPostalCode"]);
                    ordersItem.ShipCountry = (string)dataReader["ShipCountry"];

                    Orders.Add(ordersItem);
                }


            }


        }
    }
}
