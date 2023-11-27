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
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AutoStop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DayDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NightDate { get; set; }

    }
}
