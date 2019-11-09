using System;
using System.Data.SQLite;

namespace DataAccessLayer
{
    public class SQLiteAppDb: IDisposable
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
