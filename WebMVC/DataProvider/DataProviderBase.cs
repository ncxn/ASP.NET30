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
        private MySqlAppDb Db { get; set; }
        public DataProviderBase(MySqlAppDb db)
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
        public async Task<DataTable> GetDataTable(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            using var adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public async Task<DbDataReader> GetDataReader(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            await Db.Connection.OpenAsync();
            return await cmd.ExecuteReaderAsync();
        }
        public async Task<object> GetScalarValue(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            await Db.Connection.OpenAsync();
            return await cmd.ExecuteScalarAsync();
        }
        public async Task<int> ExecuteNonQuery(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
            int result = 0;
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            await Db.Connection.OpenAsync();
            result = await cmd.ExecuteNonQueryAsync();
            return result;
        }
        public async Task<int> ExecuteNonQueryWithTransaction(string commandText, CommandType commandType, List<MySqlParameter> parameters = null)
        {
            int result;
            await Db.Connection.OpenAsync();
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
                throw;
            }
            return result;
        }
    }
}