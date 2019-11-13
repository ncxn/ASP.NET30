using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using MySql.Data.MySqlClient;

namespace WebMVC.DataProvider
{
    public class DataProviderBase
    {
        public MySqlAppDb Db { get; set; }
        public DataProviderBase(MySqlAppDb db = null)
        {
            Db = db;
        }
        private MySqlParameter AddParameter(string name, object value)
        {
            try
            {
                var Parameter = new MySqlParameter()
                {
                    ParameterName = name,
                    Value = value,
                    Direction = ParameterDirection.Input
                };
                return Parameter;
            }
            catch (Exception)
            {
                throw new Exception("Invalid parameter");
            }
        }
        public List<MySqlParameter> GetParameter(string[] name, object[] value)
        {
            try
            {
                var parameters = new List<MySqlParameter>();

                for (var index = 0; index <= name.Count() - 1; index++)
                    parameters.Add(AddParameter(name[index], value[index]));
                return parameters;
            }
            catch (Exception)
            {
                throw new Exception("Invalid parameter");
            }
        }
        public async Task<DataTable> GetDataTableAsync(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
           
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            using var adapter = new MySqlDataAdapter(cmd);
            await Db.Connection.OpenAsync();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public async Task<DbDataReader> GetDataReaderAsync(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            return await cmd.ExecuteReaderAsync();
        }
        public async Task<object> GetScalarValueAsync(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
           
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            await Db.Connection.OpenAsync();
            return await cmd.ExecuteScalarAsync();
         
        }
        public async Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
            int result = 0;
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            await Db.Connection.OpenAsync();
            result = await cmd.ExecuteNonQueryAsync();
            await Db.Connection.CloseAsync();
            return result;
        }
        public async Task<int> ExecuteNonQueryWithTransactionAsync(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
            int result;
            var txn = await Db.Connection.BeginTransactionAsync();
            try
            {
                var cmd = Db.Connection.CreateCommand();
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters.ToArray());
                result = await cmd.ExecuteNonQueryAsync();
                await txn.CommitAsync();
            }
            catch
            {
                await txn.RollbackAsync();
                await Db.Connection.CloseAsync();
                throw;
             }
            return result;
        }
    }
}