using FreeSql.DataAnnotations;
using Group6_Profile.Service.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Entity
{
    /// <summary>
    /// Base Entidy
    /// </summary>
    public class BaseEntity
    {
        [Column(IsPrimary = true)]
        [Snowflake]
        public long? Id { get; set; }
        /// <summary>
        /// CreateDateTime
        /// </summary>
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// CreateUserId
        /// </summary>
        public long? CreateUserId { get; set; }
        /// <summary>
        /// UpdateDateTime
        /// </summary>
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// UpdateUserId
        /// </summary>
        public long? UpdateUserId { get; set; }
   
    }
}
