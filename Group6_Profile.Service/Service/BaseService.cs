using FreeSql;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Service
{
    /// <summary>
    /// Base service class 
    /// </summary>
    public class BaseService : IServiceTag
    {
        /// <summary>
        /// DB
        /// </summary>
        protected readonly IFreeSql _freeSql;
        /// <summary>
        ///  
        /// </summary>
        /// <param name="freeSql"></param>
        /// <param name="mapper"></param>
        public BaseService(IFreeSql freeSql)
        {
            _freeSql = freeSql;
        }
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <typeparam name="T1">Data ENtity </typeparam>
        /// <typeparam name="T2">DTO</typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        internal async Task<T2> GetById<T1, T2>(long Id) where T1 : BaseEntity
        {
            T2 user = await _freeSql.Select<T1>().Where(m => m.Id == Id).FirstAsync<T2>();
            if (user != null)
                return user;
            else
                return default;
        }

        /// <summary>
        /// Delete Data      
        /// </summary>
        /// <param name="id">1个Id</param>
        /// <returns></returns>
        internal async Task<MessageModel<string>> DeleteAsync<T>(long id) where T : BaseEntity
        {

            //must have where...
            int count = await _freeSql.Delete<T>().Where(m => id == m.Id).ExecuteAffrowsAsync();
            if (count > 0)
                return MessageModel<string>.Success("delete success");
            else
                return MessageModel<String>.Fail("delete fail");
        }

        /// <summary>
        /// delete data
        /// </summary>
        /// <param name="ids">1-N </param>
        /// <returns></returns>
        internal async Task<MessageModel<string>> DeleteAsync<T>(long[] ids) where T : BaseEntity
        {

            //must have where..
            int count = await _freeSql.Delete<T>().Where(m => ids.Contains(m.Id.Value)).ExecuteAffrowsAsync();
            if (count > 0)
                return MessageModel<string>.Success("delete success");
            else
                return MessageModel<String>.Fail("delete fail");
        }
        /// <summary>
        /// get page data
        /// </summary>
        /// <typeparam name="T1">Entity</typeparam>
        /// <typeparam name="T2">DTO</typeparam>
        /// <param name="select">where...</param>
        /// <param name="pagenum">current page</param>
        /// <param name="limit">page limit</param>
        /// <returns></returns>
        internal async Task<DataWithPage<T2>> GetPageInfor<T1, T2>(ISelect<T1> select, int pagenum, int limit) where T1 : BaseEntity
        {
            DataWithPage<T2> dataWithPage = new DataWithPage<T2>();
            dataWithPage.Data = await select.Count(out var total).Page(pagenum, limit).ToListAsync<T2>();
            dataWithPage.Count = (int)total;
            return dataWithPage;
        }
        /// <summary>
        /// update data
        /// </summary>
        /// <typeparam name="T1">entity</typeparam>
        /// <param name="dto">update infor</param>
        /// <param name="exp">lambda </param>
        /// <returns></returns>
        internal async Task<MessageModel<string>> UpdateInfor<T1>(object dto, Expression<Func<T1, bool>> exp) where T1 : BaseEntity
        {
            int count = await _freeSql.Update<T1>().SetDto(dto).Where(exp).ExecuteAffrowsAsync();
            if (count > 0)
                return MessageModel<String>.Success("save success");
            else
                return MessageModel<String>.Fail("save fail");
        }
        /// <summary>
        /// update data
        /// </summary>
        /// <typeparam name="T1">entity</typeparam>
        /// <param name="dto">field</param>
        /// <param name="exp">where</param>
        /// <returns></returns>
        internal async Task<int> Update<T1>(object dto, Expression<Func<T1, bool>> exp) where T1 : BaseEntity
        {
            int count = await _freeSql.Update<T1>().SetDto(dto).Where(exp).ExecuteAffrowsAsync();
            return count;
        }
        /// <summary>
        /// Insert Into DB
        /// </summary>
        /// <typeparam name="T1">entity</typeparam>
        /// <param name="source">data</param>
        /// <returns></returns>
        internal async Task<MessageModel<string>> InsertInfor<T1>(T1 source) where T1 : BaseEntity
        {
            var t1 = await _freeSql.Insert(source).ExecuteAffrowsAsync();
            if (t1 > 0)
                return MessageModel<String>.Success("save success");
            else
                return MessageModel<String>.Fail("save fail");
        }
        /// <summary>
        /// add Data
        /// </summary>
        /// <typeparam name="T1">entity</typeparam>
        /// <param name="source">data</param>
        /// <returns></returns>
        internal async Task<long> Insert<T1>(T1 source) where T1 : BaseEntity
        {
            _ = await _freeSql.Insert(source).ExecuteAffrowsAsync();
            return source.Id.Value;
        }
    }
}
