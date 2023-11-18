using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// Role Add DTO
    /// </summary>
    public class RoleAddDTO : BaseEditDTO
    {
        /// <summary>
        /// Role Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Role Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Menu Id
        /// </summary>
        public List<long> MenuIds { get; set; } = new List<long>();
    }

}
