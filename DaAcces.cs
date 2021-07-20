using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace NorthWind.Web.DataAccess
{
    public abstract class DaAcces
    {
        protected readonly IConfiguration configuration;

        public DaAcces(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString()
        {
            return configuration.GetConnectionString("Northwind");
        }

        public SqlConnection GetSqlConecction()
        {
            return new SqlConnection(GetConnectionString());
        }

        public object GetDbNullIfNull(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            return value;
        }


    }
}
