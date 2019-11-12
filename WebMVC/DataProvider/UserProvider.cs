using System;
using DataAccessLayer;
using SecurityHelper;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Areas.Identity.Models;
using System.Data.Common;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace WebMVC.DataProvider
{
    public class UserProvider : DataProviderBase, IUserStore<AppUser>, IUserPasswordStore<AppUser>, IPasswordHasher<AppUser>
    {
        private List<AppUser> userColection;

        public UserProvider(MySqlAppDb db) : base(db)
        {
            GetUserAsync();
        }

        private async void GetUserAsync()
        {
            var UserCls = new List<AppUser>();
            using var reader = await GetDataReaderAsync("usp_users_Identity_select_all", System.Data.CommandType.StoredProcedure);
            
            while (await reader.ReadAsync())
            {
                var user = new AppUser()
                {
                    Id = await reader.GetFieldValueAsync<string>(0),
                    Email = await reader.GetFieldValueAsync<string>(1),
                    PasswordHash = await reader.GetFieldValueAsync<string>(2),
                    UserName= await reader.GetFieldValueAsync<string>(3)
                };
                UserCls.Add(user);
            }
            await reader.CloseAsync();
            userColection = UserCls;
        }

        public async Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
        {
            var strSQL = "usp_users_Identity_Create";
            string[] paraName = new[] { "p_Id", "P_FullName","p_Email", "p_EmailConfirmed", "p_PasswordHash", "p_UserName" };
            object[] paraValue = new object[] { user.Id, user.FullName, user.Email, user.EmailConfirmed, user.PasswordHash, user.UserName };
            var parameters = GetParameter(paraName, paraValue);
            var affectedRows = await ExecuteNonQueryAsync(strSQL,CommandType.StoredProcedure, parameters);
            return affectedRows > 0
                ? IdentityResult.Success
                : IdentityResult.Failed(new IdentityError() { Description = $"Không thể tạo thành viên: {user.UserName}." });
        }

        public async Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            var strSQL = "usp_users_Delete";
            string[] paraName = new[] {"p_Id"};
            object[] paraValue = new object[] { user.Id };
            var parameters = GetParameter(paraName, paraValue);
            var affectedRows = await ExecuteNonQueryAsync(strSQL, CommandType.StoredProcedure, parameters);
            return affectedRows > 0
                ? IdentityResult.Success
                : IdentityResult.Failed(new IdentityError() { Description = $"Không thể xóa thành viên {user.UserName}." });
        }

        public void Dispose()
        {
            //Nothing to do or throw new NotImplementedException();
        }

        public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userId == null) throw new ArgumentNullException(nameof(userId));
            var user = await Task.Run(() => userColection.SingleOrDefault(x => x.Id == userId));

            if (user == null)
                return null;
            
            user.PasswordHash = null;
            return user;
        }

        public async Task<AppUser> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            var strSQL = "usp_users_Select_by_userName";
            string[] paraName = new[] { "p_UserName" };
            object[] paraValue = new object[] { userName };
            var parameters = GetParameter(paraName, paraValue);
            var reader = await GetDataReaderAsync(strSQL, CommandType.StoredProcedure, parameters);

            if (await reader.ReadAsync())
            {
                var user = new AppUser()
                {
                    Id = await reader.GetFieldValueAsync<string>(0),
                    FullName = await reader.GetFieldValueAsync<string>(1),
                    Email = await reader.GetFieldValueAsync<string>(2)
                };
                return user;             
            }
            await reader.CloseAsync();
            return null;
        }


        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

            user.NormalizedUserName = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
       
        public string HashPassword(AppUser user, string password)
        {
            return Encryptor.Md5(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(AppUser user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword == Encryptor.Md5(providedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }
    }
}
