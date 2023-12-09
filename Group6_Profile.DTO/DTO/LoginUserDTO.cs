using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// user infor dto
    /// </summary>
    public class LoginUserDTO : BaseDTO
    {
        /// <summary>
        ///  username
        /// </summary>

        public string UserName { get; set; }
        /// <summary>
        /// role Id
        /// </summary>
        public long[] RoleId { get; set; }
        /// <summary>
        /// agentId
        /// </summary>
        public long? AgentId { get; set; }
        public string UID { get; set; }
    }
}
