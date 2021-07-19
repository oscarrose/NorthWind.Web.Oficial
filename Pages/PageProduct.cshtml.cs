using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using NorthWind.Web.DataAccess;
using System.ComponentModel.DataAnnotations;
using NorthWind.Web.DataAccess.Entity;
using Northwind.WebUI.Models;

namespace Northwind.WebUI.Pages
{
    public class PageProductModel : PageModel
    {
        public List<ProductsModels> Products { get; set; }
        private readonly IConfiguration configuration;

        public PageProductModel(IConfiguration configuration)
        {

            this.configuration = configuration;
        }

        public void OnGet()
        {
            Products = new List<ProductsModels>();

            var connectionString = configuration.GetConnectionString("Northwind");


            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {

                command.CommandText = "ProductList";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var ProductsItem = new ProductsModels();


                    ProductsItem.ProductID = (int)dataReader["ProductID"];
                    ProductsItem.ProductName = (String)dataReader["ProductName"];
                    ProductsItem.SupplierID = Convert.ToInt32(dataReader["SupplierID"]);
                    ProductsItem.CategoryID = Convert.ToInt32(dataReader["CategoryID"]);
                    ProductsItem.QuantityPerUnit = (String)dataReader["QuantityPerUnit"];
                    ProductsItem.UnitPrice = Convert.ToDecimal( dataReader["UnitPrice"]);
                    ProductsItem.UnitsInStock = Convert.ToInt16(dataReader["UnitsInStock"]);
                    ProductsItem.UnitsOnOrder = Convert.ToInt16(dataReader["UnitsOnOrder"]);
                    ProductsItem.ReorderLevel = Convert.ToInt16(dataReader["ReorderLevel"]);
                    ProductsItem.Discontinued = (bool)dataReader["Discontinued"];


                    Products.Add(ProductsItem);
                }


            }


        }
    }
}
