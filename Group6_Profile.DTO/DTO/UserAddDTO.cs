using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// Add User DTO
    /// </summary>
    public class UserAddDTO : BaseEditDTO
    {
        /// <summary>
        /// Account
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        ///  UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// PassWord
        /// </summary>

        public string Password { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// Tel
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

       
    }
}
