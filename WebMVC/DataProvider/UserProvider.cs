using System;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Models;
using System.Data.Common;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WebMVC.DataProvider
{

    public class UserProvidercs : IUserStore<Users>, IUserPasswordStore<Users>
    {
        private readonly MySqlAppDb DB;

        public UserProvidercs(MySqlAppDb db)
        {
            DB = db;
        }
        public Task<IdentityResult> CreateAsync(Users user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(Users user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //Nothing to do throw new NotImplementedException();
        }

        public Task<Users> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Users> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            throw new NotImplementedException();
        }


        public Task<string> GetNormalizedUserNameAsync(Users user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(Users user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(Users user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(Users user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(Users user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(Users user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(Users user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(Users user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Users user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Users>> GetUsersAsync()
        {
            var cmd = DB.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = "procUsers_GetAll";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //BindParams(cmd);
            var rs = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return rs;
        }
        private async Task<List<Users>> ReadAllAsync(DbDataReader reader)
        {
            var UserList = new List<Users>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var u = new Users()
                    {
                        User_id = await reader.GetFieldValueAsync<int>(0),
                        User_name = await reader.GetFieldValueAsync<string>(1),
                        User_first_name = await reader.GetFieldValueAsync<string>(2),
                        User_last_name = await reader.GetFieldValueAsync<string>(3),
                        User_password = await reader.GetFieldValueAsync<string>(4),
                        User_status = await reader.GetFieldValueAsync<int>(5),
                        User_created_at = await reader.GetFieldValueAsync<DateTime>(6),
                        User_updated_at = await reader.GetFieldValueAsync<DateTime>(7)
                    };
                    UserList.Add(u);
                }
            }
            return UserList;
        }
    }
}
