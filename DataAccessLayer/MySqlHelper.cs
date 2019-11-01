using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MySqlHelper
    {
        private string ConnectionString { get; set; }
        public MySqlHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }

        public MySqlParameter CreateParameter(string name, object value, DbType dbType)
        {
            return CreateParameter(name, 0, value, dbType, ParameterDirection.Input);
        }
        public MySqlParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return CreateParameter(name, size, value, dbType, ParameterDirection.Input);
        }
        public MySqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new MySqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value
            };
        }

        public async Task<DataTable> GetDataTable(string commandText, CommandType commandType, MySqlParameter[] parameters = null)
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            using var command = new MySqlCommand(commandText, connection)
            {
                CommandType = commandType
            };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            var dataset = new DataSet();
            var dataAdaper = new MySqlDataAdapter(command);
            await dataAdaper.FillAsync(dataset);
            return dataset.Tables[0];
        }
        public async Task<DataSet> GetDataSet(string commandText, CommandType commandType, MySqlParameter[] parameters = null)
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            using var command = new MySqlCommand(commandText, connection)
            {
                CommandType = commandType
            };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            var dataset = new DataSet();
            var dataAdaper = new MySqlDataAdapter(command);
            await dataAdaper.FillAsync(dataset);
            return dataset;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0067:Dispose objects before losing scope", Justification = "<Pending>")]
        public IDataReader GetDataReader(string commandText, CommandType commandType, MySqlParameter[] parameters=null)
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var command = new MySqlCommand(commandText, connection)
            {
                CommandType = commandType
            };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        public async Task ExecuteNonQueryAsync(string commandText, CommandType commandType, MySqlParameter[] parameters)
        {
            using var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync();
            using var command = new MySqlCommand(commandText, connection)
            {
                CommandType = commandType
            };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            await command.ExecuteNonQueryAsync();
        }

        public async Task ExecuteNonQueryAsyncWithTransaction(string commandText, CommandType commandType, MySqlParameter[] parameters)
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            MySqlTransaction transactionScope = await connection.BeginTransactionAsync();
            using var command = new MySqlCommand(commandText, connection)
            {
                CommandType = commandType
            };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                await command.ExecuteNonQueryAsync();
                await transactionScope.CommitAsync();
            }
            catch (Exception)
            {
                await transactionScope.RollbackAsync();
            }
            finally
            {
               await connection.CloseAsync();
            }
        }
       
        public async Task GetScalarValue(string commandText, CommandType commandType, MySqlParameter[] parameters = null)
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            using var command = new MySqlCommand(commandText, connection)
            {
                CommandType = commandType
            };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            await command.ExecuteScalarAsync();
        }
    }
}
