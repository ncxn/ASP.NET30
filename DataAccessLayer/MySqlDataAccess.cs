using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    class MySqlDataAccess:IDatabaseHandler
    {
        private string _ConnectionString { get; set; }
        public MySqlDataAccess(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_ConnectionString);
        }
        public void CloseConnection(IDbConnection connection)
        {
            var sqlConnection = (MySqlConnection)connection;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new MySqlCommand
            {
                CommandText = commandText,
                Connection = (MySqlConnection)connection,
                CommandType = commandType
            };
        }
        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new MySqlDataAdapter((MySqlCommand)command);
        }
        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            MySqlCommand SQLcommand = (MySqlCommand)command;
            return SQLcommand.CreateParameter();
        }
    }
}
