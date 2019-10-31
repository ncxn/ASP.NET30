using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DatabaseHandlerFactory
    {
        private readonly string _connectionString;
        private readonly string _provider;
        public DatabaseHandlerFactory(string ConnectionString, string Provider)
        {
            _connectionString = ConnectionString;
            _provider = Provider.ToLower();
        }
        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler database = null;
            switch (_provider)
            {
                case "system.data.sqlclient":
                    database = new SqlDataAccess(_connectionString);
                    break;
                case "oracle.manageddataaccess.client":
                    database = new OracleDataAccess(_connectionString);
                    break;
                case "mysql.data.mysqlclient":
                    database = new MySqlDataAccess(_connectionString);
                    break;
            }
            return database;
        }
        public string GetProvider()
        {
            return _provider;
        }
     }
}
