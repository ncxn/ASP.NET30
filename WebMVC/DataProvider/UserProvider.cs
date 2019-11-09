using System;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Models;
using System.Data.Common;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace WebMVC.DataProvider
{
    public class UserProvider : DataProviderBase
    {
        private List<Users> userColection;

        public UserProvider(MySqlAppDb db) : base(db)
        {
            GetUserAsync();
        }

        private async void GetUserAsync()
        {
            var UserCls = new List<Users>();
            var reader = await GetDataReaderAsync("procUsers_GetAll", System.Data.CommandType.StoredProcedure);
            while (await reader.ReadAsync())
            {
                var user = new Users()
                {
                    User_name = await reader.GetFieldValueAsync<string>(0),
                    User_first_name = await reader.GetFieldValueAsync<string>(1),
                    User_last_name = await reader.GetFieldValueAsync<string>(2)
                };
                UserCls.Add(user);
            }
            userColection = UserCls;
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

        public async Task<Users> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userName == null) throw new ArgumentNullException(nameof(userName));
            var user = await Task.Run(() => userColection.SingleOrDefault(x => x.User_name == userName));
            
            if (user == null)
                return null;

            
            user.User_password = null;
            return user;
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
        public async Task<DataTable> GetUsersAsync()
        {
            return await GetDataTableAsync("procUsers_GetAll", System.Data.CommandType.StoredProcedure);
        }
    }
}
