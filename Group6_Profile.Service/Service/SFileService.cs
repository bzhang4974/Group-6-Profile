using AutoMapper;
using Group6_Profile.DTO.DTO;
using Group6_Profile.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Service
{
    public class SFileService : BaseService
    {
        private IMapper _mapper;
        public SFileService(IFreeSql freeSql, IMapper mapper) : base(freeSql)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Save File
        /// </summary>
        /// <param name="files"></param>
        /// <param name="sUpload"></param>
        /// <returns></returns>
        public async Task<long?> SaveData(SFileDTO files)
        {
            try
            {
                SFilesEntity sfiles = _mapper.Map<SFilesEntity>(files);
                return await Insert(sfiles);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
