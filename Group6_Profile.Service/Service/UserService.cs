using AutoMapper;
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
    /// User Service
    /// </summary>
    public class UserService : BaseService
    {
        /// <summary>
        ///  
        /// </summary>
        private readonly IMapper _mapper;
        private readonly UserRoleService _userRoleService;
        /// <summary>
        ///  
        /// </summary>
        /// <param name="freeSql"> </param>
        /// <param name="mapper"> </param>
        /// <param name="userRoleService"> </param>
        public UserService(IFreeSql freeSql, IMapper mapper, UserRoleService userRoleService) : base(freeSql)
        {
            _mapper = mapper;
            _userRoleService = userRoleService;
        }
        /// <summary>
        /// Check Login
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public async Task<LoginUserDTO> CheckLogin(string account, string password)
        {
            var userinfor = await _freeSql.Select<SUserEntity>().Where(m => m.Account == account && m.PassWord == password).IncludeMany(a => a.Roles).ToOneAsync();
            return _mapper.Map<LoginUserDTO>(userinfor);

        }
        /// <summary>
        /// Delete By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MessageModel<string>> Delete(long id)
        {
            return await DeleteAsync<SUserEntity>(id);
        }
        /// <summary>
        /// Get Admin User Infor
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="limit">每页条数</param>
        /// <param name="account">账号</param>
        /// <param name="username">用户名</param>
        /// <returns></returns>

        public async Task<DataWithPage<UserGridDTO>> GetAdminUserInforAsync(int page, int limit, string account, string username)
        {
            return await GetUserInforByCodeAsync(page, limit, account, username);
        }

        /// <summary>
        /// Ge tUserInfor ByCode 
        /// </summary>
        /// <param name="page">page </param>
        /// <param name="limit">limit</param>
        /// <param name="code">code</param>
        /// <param name="account">account</param>
        /// <param name="username">username</param>
        /// <returns></returns>
        public async Task<DataWithPage<UserGridDTO>> GetUserInforByCodeAsync(int page, int limit, string account, string username)
        {
            var select = _freeSql.Select<SUserEntity, SUserRoleEntity, SRoleEntity>().Where((a, b, c) => a.Id == b.UserId && c.Id == b.RoleId).OrderBy((a, b, c) => a.Id);

            if (string.IsNullOrEmpty(account) == false)
            {
                select = select.Where((a, b, c) => a.Account.Contains(account));
            }
            if (string.IsNullOrEmpty(username) == false)
            {
                select = select.Where((a, b, c) => a.UserName.Contains(username));
            }

            DataWithPage<UserGridDTO> dataWithPage = new DataWithPage<UserGridDTO>();
            List<UserGridDTO> user = await select.Count(out var total).Page(page, limit).ToListAsync<UserGridDTO>((a, b, c) => new UserGridDTO { Account = a.Account, CreateDateTime = a.CreateDateTime, Id = a.Id.Value, IsDelete = a.IsDelete, UserName = a.UserName, UpdateDateTime = a.UpdateDateTime, RoleName = c.Name });
            dataWithPage.Data = user;
            dataWithPage.Count = (int)total;
            return dataWithPage;
        }
        /// <summary>
        /// Get By Id 
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>

        public async Task<UserAddDTO> GetByIdAsync(long id)
        {
            var user = await _freeSql.Select<SUserEntity>().Where(a => a.Id == id).IncludeMany(a => a.Roles).ToOneAsync();
            var etidUser = _mapper.Map<UserAddDTO>(user);
            return etidUser;
        }
        /// <summary>
        /// Save user Infor
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userId"></param>
        /// <returns></returns>


        public async Task<MessageModel<string>> SaveDataAsync(UserAddDTO user, long userId)
        {
            //is exist
            var select = _freeSql.Select<SUserEntity>().Where(m => m.Account == user.Account);
            if (user.Id.HasValue)
                select.Where(m => m.Id != user.Id);
            bool exist = await select.AnyAsync();
            if (exist)
                return MessageModel<String>.Fail("The Account Is Exist");

            var selectNum = _freeSql.Select<SUserEntity>().Where(m => m.Num == user.Num);
            if (user.Id.HasValue)
                selectNum.Where(m => m.Id != user.Id);
            bool existNum = await selectNum.AnyAsync();
            if (existNum)
                return MessageModel<String>.Fail("The Num Is Exist");
            var selectName = _freeSql.Select<SUserEntity>().Where(m => m.UserName == user.UserName);
            if (user.Id.HasValue)
                selectName.Where(m => m.Id != user.Id);
            bool existName = await selectName.AnyAsync();
            if (existName)
                return MessageModel<String>.Fail("The UserName Is Exist");
            //Add
            if (user.Id.HasValue == false)
            { 
                SUserEntity userEntity = _mapper.Map<SUserEntity>(user);
                userEntity.UpdateUserId = userId;
                userEntity.CreateUserId = userId;
                var result = await InsertInfor(userEntity);
                if (result.IsSuccess)
                    _ = await _userRoleService.SetUserRoleAsync(userEntity.Id.Value, user.RoleId, userId);
                return result;
            }
            else//Edit
            {
                user.UpdateUserId = userId;
                var result = await UpdateInfor<SUserEntity>(user, (m => m.Id == user.Id));
                if (result.IsSuccess)
                    _ = await _userRoleService.SetUserRoleAsync(user.Id.Value, user.RoleId, userId);
                return result;
            }
        }
        /// <summary>
        /// Get Compant UserInfor 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="account"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<DataWithPage<UserGridDTO>> GetCompantUserInforAsync(int page, int limit, string account, string username)
        {
            var select = _freeSql.Select<SUserEntity, SUserRoleEntity, SRoleEntity>().Where((a, b, c) => a.Id == b.UserId && c.Id == b.RoleId && c.Code != "Admin").OrderBy((a, b, c) => a.Id);

            if (string.IsNullOrEmpty(account) == false)
            {
                select = select.Where((a, b, c) => a.Account.Contains(account));
            }
            if (string.IsNullOrEmpty(username) == false)
            {
                select = select.Where((a, b, c) => a.UserName.Contains(username));
            }

            DataWithPage<UserGridDTO> dataWithPage = new DataWithPage<UserGridDTO>();
            List<UserGridDTO> user = await select.Count(out var total).Page(page, limit).ToListAsync<UserGridDTO>((a, b, c) => new UserGridDTO { Account = a.Account, CreateDateTime = a.CreateDateTime, Id = a.Id.Value, IsDelete = a.IsDelete, UserName = a.UserName, UpdateDateTime = a.UpdateDateTime, RoleName = c.Name });
            dataWithPage.Data = user;
            dataWithPage.Count = (int)total;
            return dataWithPage;
        }

        /// <summary>
        /// Get By UserName
        /// </summary>
        /// <param name="cell0"></param>
        /// <returns></returns>
        public async Task<UserAddDTO> GetByUserName(string cell0)
        {
            var user = await _freeSql.Select<SUserEntity>().Where(a => a.UserName == cell0).IncludeMany(a => a.Roles).FirstAsync();
            var etidUser = _mapper.Map<UserAddDTO>(user);
            return etidUser;
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sourcePassword"></param>
        /// <param name="aimPassowrd"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<MessageModel<string>> ChangePassword(long id, string sourcePassword, string aimPassowrd)
        {
            var user = await _freeSql.Select<SUserEntity>().Where(m => m.Id == id && m.PassWord == sourcePassword).ToOneAsync();
            if (user == null)
            {
                return MessageModel<string>.Fail("Please Make Sure Password");
            }
            return await UpdateInfor<SUserEntity>(new { password = aimPassowrd }, (a => a.Id == id));
        }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<UserSelectDTO>> GetCommonUserByArea()
        {
            return _freeSql.Select<SUserEntity, SUserRoleEntity, SRoleEntity>().Where((a, b, c) => a.Id.Value == b.UserId && b.RoleId == c.Id.Value && c.Code == "TechUser").ToListAsync<UserSelectDTO>();
        }
        
    }
}
