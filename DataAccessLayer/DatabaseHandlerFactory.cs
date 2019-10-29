using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class DatabaseHandlerFactory
    {
        private readonly IConfiguration _config;
        public DatabaseHandlerFactory(IConfiguration config)
        {
            _config = config;
        }
        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler database = null;
            switch (_config["DbConnection:ProviderName"].ToLower())
            {
                case "system.data.sqlclient":
                    database = new SqlDataAccess(_config["DbConnection:ConnectionString"]);
                    break;
                case "oracle.manageddataaccess.client":
                    database = new OracleDataAccess(_config["DbConnection:ConnectionString"]);
                    break;
                case "mysql.data.mysqlclient":
                    database = new MySqlDataAccess(_config["DbConnection:ConnectionString"]);
                    break;
            }
            return database;
        }
        public string GetProviderName()
        {
            return _config["DbConnection:ProviderName"];
        }
    }
}
