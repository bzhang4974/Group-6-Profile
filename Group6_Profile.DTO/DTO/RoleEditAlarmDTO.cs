using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// 新增用户的实体
    /// </summary>
    public class RoleEditAlarmDTO : BaseEditDTO
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 报警等级
        /// </summary>
        public string AlarmLevel { get; set; }
    }
}
