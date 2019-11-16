using System;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class MySqlAppDb : IDisposable
    {
        public MySqlConnection Connection { get; }

        public MySqlAppDb(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }
        public void Dispose() => Connection.Dispose();
    }
}