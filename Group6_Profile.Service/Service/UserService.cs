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
        private readonly SFileService _fileService;
        /// <summary>
        ///  
        /// </summary>
        /// <param name="freeSql"> </param>
        /// <param name="mapper"> </param>
        /// <param name="userRoleService"> </param>
        public UserService(IFreeSql freeSql, IMapper mapper, UserRoleService userRoleService, SFileService filesService) : base(freeSql)
        {
            _mapper = mapper;
            _userRoleService = userRoleService;
            _fileService = filesService;
        }
        /// <summary>
        /// Check Login
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public async Task<LoginUserDTO> CheckLogin(string account, string password)
        {
            var userinfor = await _freeSql.Select<SUserEntity>().Where(m => m.Account == account && m.Password == password).IncludeMany(a => a.Roles).ToOneAsync();
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
        /// <param name="page">page</param>
        /// <param name="limit">limit</param>
        /// <param name="account">account</param>
        /// <param name="username">username</param>
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
            if(etidUser!=null)
            {
                etidUser.file = _fileService.GetDatasAsync(etidUser.Id.Value);
            }
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

            //Add
            if (user.Id.HasValue == false)
            {
                SUserEntity userEntity = _mapper.Map<SUserEntity>(user);
                userEntity.UpdateUserId = userId;
                userEntity.CreateUserId = userId;
                // if user is seller
                if (user.RoleId == 2)
                {
                    var maxseller = _freeSql.Select<SUserEntity>().Where(a => a.UId.StartsWith("S")).OrderByDescending(a => a.UId).First();
                    if (maxseller == null || maxseller.UId == null)
                    {
                        userEntity.UId = "S000001";
                    }
                    else
                    {
                        string max = maxseller.UId.Substring(1);
                        if (int.TryParse(max, out int maxId) == false)
                        {
                            return MessageModel<string>.Fail("Get Max SellerId Fail");
                        }
                        userEntity.UId = "S" + ((maxId + 1) + "").PadLeft(6, '0');
                    }
                }
                else if (user.RoleId == 3)
                {
                    var maxseller = _freeSql.Select<SUserEntity>().Where(a => a.UId.StartsWith("C")).OrderByDescending(a => a.UId).First();
                    if (maxseller == null || maxseller.UId == null)
                    {
                        userEntity.UId = "C000001";
                    }
                    else
                    {
                        string max = maxseller.UId.Substring(1);
                        if (int.TryParse(max, out int maxId) == false)
                        {
                            return MessageModel<string>.Fail("Get Max SellerId Fail");
                        }
                        userEntity.UId = "C" + ((maxId + 1) + "").PadLeft(6, '0');
                    }
                }

                var result = await InsertInfor(userEntity);
                if (result.IsSuccess)
                    _ = await _userRoleService.SetUserRoleAsync(userEntity.Id.Value, user.RoleId, userId);
                if (user.file != null && user.file.Count > 0)
                {
                    _fileService.SaveData(user.file, userEntity.Id.Value, "GoodsImg");
                }
                return result;
            }
            else//Edit
            {

                user.UpdateUserId = userId;
                var result = await UpdateInfor<SUserEntity>(user, (m => m.Id == user.Id));
                if (result.IsSuccess)
                    _ = await _userRoleService.SetUserRoleAsync(user.Id.Value, user.RoleId, userId);
                if (user.file != null && user.file.Count > 0)
                {
                      _fileService.SaveData(user.file, user.Id.Value, "GoodsImg");
                }
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
            var user = await _freeSql.Select<SUserEntity>().Where(m => m.Id == id && m.Password == sourcePassword).ToOneAsync();
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
        /// <summary>
        /// ResetPasswordAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public async Task<MessageModel<string>> ResetPasswordAsync(ResetPasswordDTO user, int v)
        {
            if (user.Password != user.ConfirmPassword)
            {
                return MessageModel<string>.Fail("Please Make Sure Password");
            }
            var dbuser = _freeSql.Select<SUserEntity>().Where(a => a.Tel == user.Tel && a.UserName == user.UserName).First();
            if (dbuser == null)
            {
                return MessageModel<string>.Fail("not exust this user");
            }
            return await UpdateInfor<SUserEntity>(new { password = user.Password }, (a => a.Id == dbuser.Id));
        }
        /// <summary>
        /// Get Seller Infor
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>

        public MessageModel<UserInforDTO> GetSeller(string uId)
        {
            UserInforDTO user = _freeSql.Select<SUserEntity, SUserRoleEntity>().Where((a, b) => a.IsDelete == false && a.UId == uId && a.Id == b.UserId && b.RoleId == 2).ToOne<UserInforDTO>((a, b) => new UserInforDTO { Address = a.Address, Tel = a.Tel, UID = a.UId, UserName = a.UserName });
            if (user == null)
            {
                return MessageModel<UserInforDTO>.Fail("can not find this user");
            }
            return MessageModel<UserInforDTO>.Success("success", user);
        }
        /// <summary>
        /// Get Buyer Infor
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>

        public MessageModel<UserInforDTO> GetBuyer(object uId)
        {
            UserInforDTO user = _freeSql.Select<SUserEntity, SUserRoleEntity>().Where((a, b) => a.IsDelete == false && a.UId == uId && a.Id == b.UserId && b.RoleId == 3).ToOne<UserInforDTO>((a, b) => new UserInforDTO { Address = a.Address, Tel = a.Tel, UID = a.UId, UserName = a.UserName });
            if (user == null)
            {
                return MessageModel<UserInforDTO>.Fail("can not find this user");
            }
            return MessageModel<UserInforDTO>.Success("success", user);
        }
    }
}
