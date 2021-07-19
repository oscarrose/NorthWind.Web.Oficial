using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using NorthWind.Web.DataAccess;
using System.ComponentModel.DataAnnotations;
using NorthWind.Web.DataAccess.Entity;
using Northwind.WebUI.Models;
using StackExchange.Redis;

namespace Northwind.WebUI.Pages
{
    public class PageOrdersModel : PageModel
    {
        private readonly IConfiguration configuration;
   
        public SelectList Customers { get; set; }
       
        public SelectList Employees { get; set; }
        
        public SelectList Products { get; set; }
     
        public SelectList Shippers { get; set; }

        public string ErrorMessage { get; set; }

        [BindProperty]
        public OrdersModel Orders { get; set; }
        public void OnGet()
        {
            llenarselectitems();


        }

        public PageOrdersModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// llenar los select item
        /// </summary>
        private void llenarselectitems()
        {
            var customersDao = new CustomerDa(configuration);

            var customers = customersDao.GetCutomers();
            Customers = new SelectList(customers, "CustomerID", "CompanyName");

            var EmployeesDao = new EmployeesDao(configuration);

            var employees =EmployeesDao.GetEmployees();
            Employees = new SelectList(employees,
               nameof(Employeesitems.EmployeeID),
               nameof(Employeesitems.EmployeeName));

            var productDa = new ProductsListDa(configuration);

            var products = productDa.GetProducts();
            Products = new SelectList(products,
              nameof(ProductsListItem.ProductID),
                nameof(ProductsListItem.ProductName));

            var shippersDao = new EmployeesDao.ShippersDa(configuration);

            var shippers = shippersDao.GetShippers();
            Shippers = new SelectList(shippers,
               nameof(ShippersListItem.ShipperID),
               nameof(ShippersListItem.CompanyName));
        }


        
    }
}
