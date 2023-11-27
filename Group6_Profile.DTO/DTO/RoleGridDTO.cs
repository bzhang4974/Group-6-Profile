using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// Role Table DTO
    /// </summary>
    public class RoleGridDTO : BaseDTO
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
        /// CreateDateTime
        /// </summary>
        public DateTime? CreateDateTime { get; set; }
        /// <summary>
        /// UpdateDateTime
        /// </summary>
        public DateTime? UpdateDateTime { get; set; }
    }
}
