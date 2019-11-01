using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    class MySqlDataAccess : IDatabaseHandler
    {
        private string _connectionString { get; set; }
        public MySqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        public void CloseConnection(DbConnection connection)
        {
            var sqlConnection = (MySqlConnection)connection;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        public DbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new MySqlCommand
            {
                CommandText = commandText,
                Connection = (MySqlConnection)connection,
                CommandType = commandType
            };
        }
        public DataAdapter CreateAdapter(DbCommand command)
        {
            return new MySqlDataAdapter((MySqlCommand)command);
        }
        public IDbDataParameter CreateParameter(DbCommand command)
        {
            MySqlCommand SQLcommand = (MySqlCommand)command;
            return SQLcommand.CreateParameter();
        }
    }
}
