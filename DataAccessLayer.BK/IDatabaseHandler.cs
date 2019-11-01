using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DataAccessLayer
{
    public interface IDatabaseHandler
    {
        DbConnection CreateConnection();
        void CloseConnection(DbConnection connection);
        DbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection);
        DataAdapter CreateAdapter(DbCommand command);
        IDbDataParameter CreateParameter(DbCommand command);
    }
}
