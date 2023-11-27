using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Entity
{
    [Table(Name = "S_Role_Menu")]
    internal class SRoleMenuEntity : BaseEntity
    {
        /// <summary>
        /// Menu Id
        /// </summary>
        public long MenuId { get; set; }
        /// <summary>
        /// Role Id
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// MenuId
        /// </summary>
        [Navigate("MenuId")]
        public virtual SMenuEntity User { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        [Navigate("RoleId")]
        public virtual SRoleEntity Role { get; set; }
    }
}
