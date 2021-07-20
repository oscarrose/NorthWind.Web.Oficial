using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Web.DataAccess.Entity;
using Microsoft.Extensions.Configuration;
using Dapper;


namespace NorthWind.Web.DataAccess
{
   public  class ProductsListDa : DaAcces
   {

        public ProductsListDa(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<ProductsListItem> GetProducts()
        {
            var connection = GetSqlConecction();
            return connection.Query<ProductsListItem>("select ProductID, ProductName FROM Products ORDER BY ProductName");

        }
    }
}
