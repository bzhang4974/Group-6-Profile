using AutoMapper;
using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Service
{
    /// <summary>
    /// Role Service
    /// </summary>
    public class RoleService : BaseService
    {
        /// <summary>
        ///  
        /// </summary>
        private readonly IMapper _mapper;
        private readonly RoleMenuService _roleMenuService;
        /// <summary>
        ///  
        /// </summary>
        /// <param name="freeSql"></param>
        public RoleService(IFreeSql freeSql, IMapper mapper, RoleMenuService roleMenuService) : base(freeSql)
        {
            _mapper = mapper;
            _roleMenuService = roleMenuService;
        }
        /// <summary>
        ///Delete By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<MessageModel<string>> Delete(long id)
        {
            return await DeleteAsync<SRoleEntity>(id);
        }
        /// <summary>
        /// Get All Role
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleDTO>> GetAllRoleAsync()
        {
            return await _freeSql.Select<SRoleEntity>().ToListAsync<RoleDTO>();
        }
        /// <summary>
        /// Get All Admin Role
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleDTO>> GetAllAdminRoleAsync()
        {
            return await _freeSql.Select<SRoleEntity>().Where(a => a.Code != "Admin").ToListAsync<RoleDTO>();
        }


        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>

        public async Task<RoleAddDTO> GetByIdAsync(long id)
        {
            var role = await _freeSql.Select<SRoleEntity>().Where(a => a.Id == id).ToOneAsync<RoleAddDTO>(a => new RoleAddDTO { Id = a.Id, Code = a.Code, Name = a.Name, MenuIds = _freeSql.Select<SRoleMenuEntity>().Where(b => b.RoleId == a.Id).ToList(a => a.MenuId) });
            return role;
        }


        /// <summary>
        /// Get Page Infor
        /// </summary>
        /// <param name="page">page</param>
        /// <param name="limit">limit</param>
        /// <param name="name">role name</param>
        /// <returns></returns>

        public async Task<DataWithPage<RoleGridDTO>> GetRoleInforAsync(int page, int limit, string name)
        {
            var select = _freeSql.Select<SRoleEntity>().OrderBy(a => a.Id);
            if (string.IsNullOrEmpty(name) == false)
            {
                select = select.Where(m => m.Name == name);
            }
            return await GetPageInfor<SRoleEntity, RoleGridDTO>(select, page, limit);
        }
        /// <summary>
        /// save role 
        /// </summary>
        /// <param name="roleadd"> </param>
        /// <param name="userId"> </param>
        /// <returns></returns>
        public async Task<MessageModel<string>> SaveDataAsync(RoleAddDTO roleadd, long userId)
        {
            //Already Exists
            var select = _freeSql.Select<SRoleEntity>().Where(m => m.Code == roleadd.Code || m.Name == roleadd.Name);
            if (roleadd.Id.HasValue)
                select.Where(m => m.Id != roleadd.Id);
            bool exist = await select.AnyAsync();
            if (exist)
                return MessageModel<String>.Fail("The Role Already Exists");
            //Add
            if (roleadd.Id.HasValue == false)
            {
                
                SRoleEntity roleEntity = _mapper.Map<SRoleEntity>(roleadd);
                roleEntity.UpdateUserId = userId;
                roleEntity.CreateUserId = userId;
                var result = await InsertInfor(roleEntity);
               
                if (result.IsSuccess)
                    await _roleMenuService.SetRoleMenu(roleEntity.Id.Value, roleadd.MenuIds, userId);
                return result;
            }
            else//Edit
            {
                roleadd.UpdateUserId = userId;
                var result = await UpdateInfor<SRoleEntity>(roleadd, (m => m.Id == roleadd.Id));
               
                if (result.IsSuccess)
                    await _roleMenuService.SetRoleMenu(roleadd.Id.Value, roleadd.MenuIds, userId);
                return result;
            }
        }
       
       
    }
}
