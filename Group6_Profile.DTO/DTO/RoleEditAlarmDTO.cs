using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// New user entity
    /// </summary>
    public class RoleEditAlarmDTO : BaseEditDTO
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Alarm level
        /// </summary>
        public string AlarmLevel { get; set; }
    }
}
