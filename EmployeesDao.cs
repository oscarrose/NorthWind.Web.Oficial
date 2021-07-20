using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using NorthWind.Web.DataAccess.Entity;


namespace NorthWind.Web.DataAccess
{
    public class EmployeesDao : DaAcces
    {
        public EmployeesDao(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<Employeesitems> GetEmployees()
        {
            var connection = GetSqlConecction();
            return connection.Query<Employeesitems>("select EmployeeID, CONCAT(FirstName, ' ', LastName) EmployeeName from Employees");
        }

        public class ShippersDa : DaAcces
        {
            public ShippersDa(IConfiguration configuration) : base(configuration)
            {

            }

            public IEnumerable<ShippersListItem> GetShippers()
            {
                var connection = GetSqlConecction();
                return connection.Query<ShippersListItem>("select ShipperID, CompanyName FROM Shippers");
            }
        }
    }
}
