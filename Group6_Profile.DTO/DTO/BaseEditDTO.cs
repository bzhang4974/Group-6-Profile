using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// base edit dto
    /// </summary>
    public class BaseEditDTO : BaseDTO
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public long UpdateUserId { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [JsonIgnore]
        public DateTime? UpdateDateTime { get; set; } = DateTime.Now;
        /// <summary>
        ///  
        /// </summary>
        [JsonIgnore]
        public string UpdateUserName { get; set; }  
    }
}
