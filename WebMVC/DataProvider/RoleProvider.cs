using System;
using System.Data;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.DataProvider
{
    public class RoleProvider: IRoleStore<Roles>
    {
        private readonly MySqlAppDb DB;
        private Roles Roles { get; set; }
        public RoleProvider(MySqlAppDb db)
        {
            DB = db;
        }

        public async Task<IdentityResult> CreateAsync(Roles role, CancellationToken cancellationToken)
        {
            var cmd = DB.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = "usp_tblRole_Insert";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            //Id = (int)cmd.LastInsertedId;
            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(Roles role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //nothing to do: throw new NotImplementedException();
        }

        public Task<Roles> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Roles> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(Roles role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(Roles role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(Roles role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(Roles role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(Roles role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Roles role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@p_role_name",
                DbType = DbType.String,
                Value = Roles.Role_name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@p_role_description",
                DbType = DbType.String,
                Value = Roles.Role_description,
            });
        }
    }
}
