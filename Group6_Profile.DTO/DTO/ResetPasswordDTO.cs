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
    public class ResetPasswordDTO : BaseEditDTO
    {

        /// <summary>
        ///  UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Tel
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// PassWord
        /// </summary>

        public string Password { get; set; }
    
        /// <summary>
        /// Address
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
}
