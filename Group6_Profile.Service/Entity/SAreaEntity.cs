using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Group6_Profile.Service.Entity
{
    [Table(Name = "S_Area")]
    public class SAreaEntity : BaseEntity
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 区域编号
        /// </summary>
        public string BH { get; set; }
        /// <summary>
        /// 自动停报
        /// </summary>
        public int AutoStop { get; set; }
        /// <summary>
        /// 白班时间
        /// </summary>
        public string DayDate { get; set; }
        /// <summary>
        /// 夜班时间
        /// </summary>
        public string NightDate { get; set; }

    }
}
