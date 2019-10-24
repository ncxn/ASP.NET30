using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DataAccessLayer
{
    public class DatabaseHandlerFactory
    {
        private readonly ConnectionStringSettings _connectionStringSettings;
        public DatabaseHandlerFactory(string connectionStringName)
        {
            _connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
        }
        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler database = null;
            switch (_connectionStringSettings.ProviderName.ToLower())
            {
                case "system.data.sqlclient":
                    database = new SqlDataAccess(_connectionStringSettings.ConnectionString);
                    break;
                case "oracle.manageddataaccess.client":
                    database = new OracleDataAccess(_connectionStringSettings.ConnectionString);
                    break;
                case "mysql.data.mysqlclient":
                    database = new MySqlDataAccess(_connectionStringSettings.ConnectionString);
                    break;
            }
            return database;
        }
        public string GetProviderName()
        {
            return _connectionStringSettings.ProviderName;
        }
    }
}
