using Group6_Profile.DTO.DTO;
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
    /// Role Menu Relationship
    /// </summary>
    public class RoleMenuService : BaseService
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="freeSql"></param>
        public RoleMenuService(IFreeSql freeSql) : base(freeSql)
        {
        }
        /// <summary>
        ///  Get First Menu By RoleId
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>

        public async Task<string> GetFirstMenuAsync(long[] roleid)
        {
            string url = await _freeSql.Select<SMenuEntity, SRoleMenuEntity>().Where((a, b) => a.Id == b.MenuId && a.IsFirstPage == true && roleid.Contains(b.RoleId) && a.IsDelete == false).ToOneAsync((a, b) => a.Url);
            return url;
        }
        /// <summary>
        /// Get All Menu
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<MenuDTO>> GetMenuAsync(long[] roleid)
        {
            List<MenuDTO> menus = await _freeSql.Select<SMenuEntity, SRoleMenuEntity>().Where((a, b) => a.Id == b.MenuId && a.IsFirstPage == false && roleid.Contains(b.RoleId) && a.IsDelete == false).OrderBy((a, b) => a.OrderIndex).ToListAsync<MenuDTO>();
            return menus;
        }
        /// <summary>
        /// Set Role Menu
        /// </summary>
        /// <param name="roleId">RoleId</param>
        /// <param name="menuIds">Menu Ids</param>
        /// <param name="douserId">UserId</param>

        internal async Task<MessageModel<string>> SetRoleMenu(long roleId, List<long> menuIds, long douserId)
        {
            List<long> existIds = new List<long>(menuIds.Count);
            foreach (var menuId in menuIds)
            {
                SRoleMenuEntity roleMenu = await _freeSql.Select<SRoleMenuEntity>().Where(a => a.RoleId == roleId && a.MenuId == menuId).FirstAsync();
                //Edit
                if (roleMenu != null)
                {
                    _ = Update<SRoleMenuEntity>(new { UpdateUserId = douserId, UpdateDateTime = DateTime.Now, IsDelete = false }, a => a.Id == roleMenu.Id);
                    existIds.Add(roleMenu.Id.Value);
                }
                else//Add
                {
                    SRoleMenuEntity obj = new SRoleMenuEntity();
                    obj.RoleId = roleId;
                    obj.MenuId = menuId;
                    obj.CreateUserId = douserId;
                    obj.UpdateUserId = douserId;
                    _ = Insert<SRoleMenuEntity>(obj);
                    existIds.Add(obj.Id.Value);
                }
            }
            _ = _freeSql.Delete<SRoleMenuEntity>().Where(a => existIds.Contains(a.Id.Value) == false && a.RoleId == roleId).ExecuteAffrowsAsync();
            return MessageModel<string>.Success("Saved Successfully");
        }
    }
}
