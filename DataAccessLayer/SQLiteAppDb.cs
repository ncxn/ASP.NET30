using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DataAccessLayer
{
    class SQLiteAppDb: IDisposable
    {
        public SQLiteConnection Connection;
        public SQLiteAppDb(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
