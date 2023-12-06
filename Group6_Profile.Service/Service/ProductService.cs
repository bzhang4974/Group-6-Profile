using AutoMapper;
using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Service
{
    public class ProductService : BaseService
    {
        /// <summary>
        ///  
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///  
        /// </summary>
        /// <param name="freeSql"></param>
        public ProductService(IFreeSql freeSql, IMapper mapper) : base(freeSql)
        {
            _mapper = mapper;

        }
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>

        public async Task<MessageModel<string>> Edit(ProductDTO product)
        {
            UserInforDTO user = _freeSql.Select<SUserEntity, SUserRoleEntity>().Where((a, b) => a.IsDelete == false && a.UId == product.sid && a.Id == b.UserId && b.RoleId == 2).ToOne<UserInforDTO>((a, b) => new UserInforDTO { Address = a.Address, Tel = a.Tel, UID = a.UId, UserName = a.UserName });
            if (user == null)
            {
                return MessageModel<string>.Fail("can not find this user");
            }
            bool exist = _freeSql.Select<ProductEntity>().Any(a => a.pid == product.pid);
            if (exist == false)
            {
                return MessageModel<string>.Fail("not find this product");
            }
            return await UpdateInfor<ProductEntity>(product, (a => a.pid == product.pid));
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns> 
        public async Task<MessageModel<string>> Add(ProductDTO product)
        {
            UserInforDTO user = _freeSql.Select<SUserEntity, SUserRoleEntity>().Where((a, b) => a.IsDelete == false && a.UId == product.sid && a.Id == b.UserId && b.RoleId == 2).ToOne<UserInforDTO>((a, b) => new UserInforDTO { Address = a.Address, Tel = a.Tel, UID = a.UId, UserName = a.UserName });
            if (user == null)
            {
                return MessageModel<string>.Fail("can not find this user");
            }
            bool exist = _freeSql.Select<ProductEntity>().Any(a => a.pid == product.pid);
            if (exist)
            {
                return MessageModel<string>.Fail(" this product has exist");
            }
            ProductEntity productEntity = _mapper.Map<ProductEntity>(product);
            return await InsertInfor<ProductEntity>(productEntity);
        }
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns> 
        public MessageModel<string> Delete(string pid)
        {
            bool exist = _freeSql.Select<ProductEntity>().Any(a => a.pid == pid);
            if (exist==false)
            {
                return MessageModel<string>.Fail(" not find this product");
            }

            int count = _freeSql.Delete<ProductEntity>().Where(a => a.pid == pid).ExecuteAffrows();
            if (count > 0)
                return MessageModel<string>.Success("delete success");
            else
                return MessageModel<String>.Fail("delete fail");
        }
    }
}
