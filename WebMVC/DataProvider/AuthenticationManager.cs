using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using MySql.Data.MySqlClient;
using WebMVC.ViewModels;
using SecurityHelper;

namespace WebMVC.DataProvider
{
    public class AuthenticationManager : DataProviderBase
    {
        public AuthenticationManager(MySqlAppDb db) : base(db)
        {

        }
        public async Task<LoginViewModel> LoginAsync(string email, string password)
        {
            List<MySqlParameter> paramerters = new List<MySqlParameter>()
            {
                new MySqlParameter ("p_user_email", email),
                new MySqlParameter("p_user_password", Encryptor.Md5(password))
            };

            var reader = await GetDataReader("usp_check_login_info", System.Data.CommandType.StoredProcedure, paramerters);

            if (await reader.ReadAsync())
            {
                LoginViewModel model = new LoginViewModel()
                {
                   Email= await reader.GetFieldValueAsync<string>(0),
                   Password= await reader.GetFieldValueAsync<string>(1),
                };
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}
