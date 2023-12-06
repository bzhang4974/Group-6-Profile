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
    /// Menu
    /// </summary>
    public class MenuService : BaseService
    {
        private readonly IMapper _mapper;

        /// <summary>
        ///  
        /// </summary>
        /// <param name="freeSql"></param>
        public MenuService(IFreeSql freeSql, IMapper mapper) : base(freeSql)
        {
            _mapper = mapper;
        }
        /// <summary>
        ///Delete By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<MessageModel<string>> Delete(long id)
        {
            return await DeleteAsync<SMenuEntity>(id);
        }
        /// <summary>
        /// Get All First Page
        /// </summary>
        /// <returns></returns>

        public async Task<List<MenuSelectDTO>> GetAllFirstPage()
        {
            return await _freeSql.Select<SMenuEntity>().Where(a => a.IsDelete == false && a.IsFirstPage == true).ToListAsync<MenuSelectDTO>();
        }
        /// <summary>
        /// Get left Menu
        /// </summary>
        /// <returns></returns>
        public async Task<List<MenuSelectDTO>> GetAllLeftMenu(long roleid)
        {
            return await _freeSql.Select<SMenuEntity>().Where(a => a.IsDelete == false && a.IsFirstPage == false && ("," + a.RoleIds + ",").Contains("," + roleid + "，")).OrderBy(a => a.OrderIndex).ToListAsync<MenuSelectDTO>();
        }
        /// <summary>
        /// Get Menu By Id A
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public async Task<MenuAddDTO> GetByIdAsync(long id)
        {
            return await GetById<SMenuEntity, MenuAddDTO>(id);
        }
        /// <summary>
        /// Get Page Menu Infor
        /// </summary>
        /// <param name="page">Page Number</param>
        /// <param name="limit">Page Limit</param>
        /// <param name="name">Role Name</param>
        /// <returns></returns>

        public async Task<DataWithPage<MenuGridDTO>> GetMenuInforAsync(int page, int limit, string name)
        {
            var select = _freeSql.Select<SMenuEntity>().OrderBy(a => a.OrderIndex);
            if (string.IsNullOrEmpty(name) == false)
            {
                select = select.Where(m => m.Name == name);
            }
            return await GetPageInfor<SMenuEntity, MenuGridDTO>(select, page, limit);
        }
        /// <summary>
        /// Save Data
        /// </summary>
        /// <param name="menuadd"> </param>
        /// <param name="userId"> </param>
        /// <returns></returns>
        public async Task<MessageModel<string>> SaveDataAsync(MenuAddDTO menuadd, long userId)
        {
            //is exist
            var codeselect = _freeSql.Select<SMenuEntity>().Where(a => a.Code == menuadd.Code);
            if (menuadd.Id.HasValue)
                codeselect = codeselect.Where(a => a.Id != menuadd.Id);
            if (await codeselect.AnyAsync())
                return MessageModel<String>.Fail("The Menu Code Is Exist");
            var select = _freeSql.Select<SMenuEntity>().Where(m => m.OrderIndex == menuadd.OrderIndex && m.Name == menuadd.Name && menuadd.Url == m.Url);
            if (menuadd.Id.HasValue)
                select.Where(m => m.Id != menuadd.Id);
            bool exist = await select.AnyAsync();
            if (exist)
                return MessageModel<String>.Fail("The Menu Is Exist");
            //add
            if (menuadd.Id.HasValue == false)
            {
                
                SMenuEntity menuEntity = _mapper.Map<SMenuEntity>(menuadd);
                menuEntity.UpdateUserId = userId;
                menuEntity.CreateUserId = userId;
                var result = await InsertInfor(menuEntity);

                return result;
            }
            else//edit
            {
                menuadd.UpdateUserId = userId;
                var result = await UpdateInfor<SMenuEntity>(menuadd, (m => m.Id == menuadd.Id));
                return result;
            }
        }
    }
}
