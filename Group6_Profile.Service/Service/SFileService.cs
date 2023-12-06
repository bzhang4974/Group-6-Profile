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
        public SFileDTO GetDataByDataIdAsync(long key)
        {
            return _freeSql.Select<SFilesEntity>().Where(a => a.DataID == key).ToOne<SFileDTO>();
        }
        public SFileDTO GetDataAsync(long key)
        {
            return _freeSql.Select<SFilesEntity>().Where(a => a.Id == key).ToOne<SFileDTO>();
        }
        public List<SFileDTO> GetDatasAsync(long key)
        {
            return _freeSql.Select<SFilesEntity>().Where(a => a.DataID == key).ToList<SFileDTO>();
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
        /// <summary>
        /// 保存图片 保存数据用
        /// </summary>
        /// <param name="files"></param>
        /// <param name="DataID"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool SaveData(List<SFileDTO> files, long DataID, string Code)
        {
            try
            {
                string validID = "";
                if (files != null && files.Count > 0)
                {
                    foreach (var upload in files)
                    {
                        upload.DataID = DataID;
                        upload.Code = Code;
                        if (upload.Id.HasValue)//编辑
                        {

                            var dbuser = _freeSql.Select<SFilesEntity>().Where(a => a.Id == upload.Id.Value).First();
                            if (dbuser == null)
                                return false;
                            else
                            {

                                UpdateInfor<SFilesEntity>(new { Code = upload.Code, DataId = upload.DataID }, (a) => a.Id == upload.Id);
                            }

                            validID += "'" + upload.Id + "',";
                        }
                    }
                }

                if (string.IsNullOrEmpty(validID)) // 删除所有数据
                {
                    _freeSql.Delete<SFilesEntity>().Where(m => m.DataID == DataID && m.Code == Code).ExecuteDeleted();

                }
                else  //删除部分图片
                {
                    
                        //string sql = $" delete from S_Files where  Code='{Code}' and DataId='{DataID}' and ID not in(" + validID.TrimEnd(',') + ")";

                    _freeSql.Select<SFilesEntity>().Where(a => a.Code == Code && a.DataID == DataID).WithSql(" and ID not in(" + validID.TrimEnd(',') + ")"); ;
                  
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
