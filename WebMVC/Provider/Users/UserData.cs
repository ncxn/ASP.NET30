using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using DataAccessLayer;

namespace WebMVC.Provider
{
    public class UserData
    {
        private readonly MySqlHelper _AppDb;
        private List<Users> _users;
        public UserData(MySqlHelper AppDB)
        {
            _AppDb = AppDB;
            _users = GetList(); ;
        }

        private List<Users> GetList()
        {
            List<Users> UserList = new List<Users>();
            IDataReader Reader = _AppDb.GetDataReader("procUsers_GetAll", CommandType.StoredProcedure);

            while (Reader.Read())
            {
                Users objUser = new Users()
                {
                    User_name = Reader["user_name"].ToString(),
                    User_first_name = Reader["user_first_name"].ToString(),
                    User_last_name = Reader["user_last_name"].ToString(),
                    User_email = Reader["user_email"].ToString(),
                    User_status = System.Convert.ToInt32(Reader["user_status"]),
                    User_created_at = (DateTime)Reader["user_created_at"],
                    User_updated_at = (DateTime)Reader["user_updated_at"]
                };
                UserList.Add(objUser);
            }
            Reader.Close();

            return UserList;
        }
        public async Task<Users> FindByNameAsync(string normalizedUserName)
        {
           return await Task.Run(() => _users.FirstOrDefault(u => u.User_name == normalizedUserName));
        }
    }
}
