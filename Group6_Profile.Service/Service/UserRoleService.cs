using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Service
{
    /// <summary>
    /// User Role
    /// </summary>
    public class UserRoleService : BaseService
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="freeSql"></param>
        public UserRoleService(IFreeSql freeSql) : base(freeSql)
        {
        }

        /// <summary>
        /// Set User Role
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="roleId">roleId</param>
        /// <param name="douserId">douserId</param>
        /// <returns></returns>
        public async Task<MessageModel<string>> SetUserRoleAsync(long userId, long roleId, long douserId)
        {

            SUserRoleEntity userRole = await _freeSql.Select<SUserRoleEntity>().Where<SUserRoleEntity>(a => a.UserId == userId).FirstAsync();
            //edit
            if (userRole != null)
            {
                _ = Update<SUserRoleEntity>(new { roleId = roleId, UpdateUserId = douserId, UpdateDateTime = DateTime.Now, IsDelete = false }, a => a.Id == userRole.Id);

            }
            else//add
            {
                userRole = new SUserRoleEntity();
                userRole.RoleId = roleId;
                userRole.UserId = userId;
                userRole.CreateUserId = douserId;
                userRole.UpdateUserId = douserId;
                _ = Insert<SUserRoleEntity>(userRole);
            }
            return MessageModel<string>.Success("Save Success");
        }
    }
}
