using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.MessageBody
{
    /// <summary> 
    /// Page Infor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataWithPage<T>
    {   /// <summary>
        /// Total Page
        /// </summary>
        public long Count { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();
        /// <summary>
        /// Code
        /// </summary>
        public int Code { get; set; } = 0;
        /// <summary>
        /// Msg
        /// </summary>
        public string Msg { get; set; } = "";
    }
}
