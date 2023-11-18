using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Entity
{
    [Table(Name = "S_User_Role")]
    internal class SUserRoleEntity : BaseEntity
    {
        /// <summary>
        /// UserId
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// User
        /// </summary>
        [Navigate("UserId")]
        public virtual SUserEntity User { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        [Navigate("RoleId")]
        public virtual SRoleEntity Role { get; set; }
    }
}
