using System;
using System.Collections.Generic;
using NorthWind.Web.DataAccess.Entity;
using Microsoft.Extensions.Configuration;
using Dapper;


namespace NorthWind.Web.DataAccess
{
    public class CustomerDa :DaAcces
    {
        

        public CustomerDa(IConfiguration configuration): base(configuration)
        {
           
        }

        public IEnumerable<Customers> GetCutomers()
        {
            var connection = GetSqlConecction();
            return connection.Query<Customers>("select CustomerID, CompanyName from Customers");

        }
    }
}
