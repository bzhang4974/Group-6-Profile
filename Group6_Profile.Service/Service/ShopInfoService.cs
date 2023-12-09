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
    public class ShopInfoService : BaseService
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
        public ShopInfoService(IFreeSql freeSql, IMapper mapper, RoleMenuService roleMenuService) : base(freeSql)
        {
            _mapper = mapper;
            _roleMenuService = roleMenuService;
        }

        public ShopInfoDTO GetById(long sellerId)
        {
            return _freeSql.Select<ShopInfoEntity>().Where(a => a.SellerId == sellerId).ToOne<ShopInfoDTO>();
        }
        /// <summary>
        /// save shop info 
        /// </summary>
        /// <param name="roleadd"> </param>
        /// <param name="userId"> </param>
        /// <returns></returns>
        public async Task<MessageModel<string>> SaveDataAsync(ShopInfoDTO shopinfo)
        {
     
            if (shopinfo.Id.HasValue == false)
            {

                ShopInfoEntity roleEntity = _mapper.Map<ShopInfoEntity>(shopinfo);
                roleEntity.UpdateUserId = shopinfo.SellerId.Value;
                roleEntity.CreateUserId = shopinfo.SellerId.Value;
                var result = await InsertInfor(roleEntity);
                return result;
            }
            else//Edit
            {
                shopinfo.UpdateUserId = shopinfo.SellerId.Value;
                var result = await UpdateInfor<ShopInfoEntity>(shopinfo, (m => m.Id == shopinfo.Id));
 
                return result;
            }
        }

    }
}
