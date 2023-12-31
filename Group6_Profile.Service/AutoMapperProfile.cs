﻿using AutoMapper;
using Group6_Profile.DTO.DTO;
using Group6_Profile.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service
{
    /// <summary>
    ///  
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        ///  
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<SFileDTO, SFilesEntity>();
            CreateMap<SFilesEntity, SFileDTO>();
            //Entity-->DTO
            CreateMap<SUserEntity, LoginUserDTO>().ForMember(d => d.RoleId
            , o => o.MapFrom(a => a.Roles.Select(a => a.Id.Value).ToArray()));

            CreateMap<SUserEntity, UserAddDTO>().ForMember(d => d.RoleId
          , o => o.MapFrom(a => a.Roles.Select(a => a.Id.Value).FirstOrDefault()));
            CreateMap<SUserEntity, UserGridDTO>();
            //DTO-->Entity
            CreateMap<UserAddDTO, SUserEntity>().ForMember(a=>a.file,o=>o.MapFrom(c=>c.file));
            CreateMap<RoleAddDTO, SRoleEntity>();
            CreateMap<MenuAddDTO, SMenuEntity>();

        

            CreateMap<SUserEntity, UserRoleInforDTO>();
            CreateMap<ProductDTO, ProductEntity>();
            CreateMap<ShopInfoDTO, ShopInfoEntity>();
            CreateMap<ShopInfoEntity, ShopInfoDTO>();
        }
    }
}
