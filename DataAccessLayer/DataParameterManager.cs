using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    class DataParameterManager
    {
        public static IDbDataParameter CreateParameter(string providerName, string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;
            switch (providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return CreateSqlParameter(name, value, dbType, direction);
                case "oracle.manageddataaccess.client":
                    return CreateOracleParameter(name, value, dbType, direction);
                case "mysql.data.mysqlclient":
                    return CreateMySqlParameter(name, value, dbType, direction);
            }
            return parameter;
        }
        public static IDbDataParameter CreateParameter(string providerName, string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;
            switch (providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return CreateSqlParameter(name, size, value, dbType, direction);
                case "oracle.manageddataaccess.client":
                    return CreateOracleParameter(name, size, value, dbType, direction);
                case "mysql.data.mysqlclient":
                    return CreateMySqlParameter(name, size, value, dbType, direction);
             }
            return parameter;
        }
        private static IDbDataParameter CreateSqlParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateSqlParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
        private static IDbDataParameter CreateOracleParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new OracleParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
        private static IDbDataParameter CreateOracleParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new OracleParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
        private static IDbDataParameter CreateMySqlParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new OracleParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
        private static IDbDataParameter CreateMySqlParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new OracleParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
    }
}
