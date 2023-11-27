using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Entity
{
    [Table(Name = "S_Role")]
    internal class SRoleEntity : BaseEntity
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
        ///  a role to mant user
        /// </summary>
        [Navigate(ManyToMany = typeof(SUserRoleEntity))]
        public virtual List<SUserEntity> Users { get; set; } = new List<SUserEntity>();
        /// <summary>
        ///   a role to mant menu
        /// </summary>
        [Navigate(ManyToMany = typeof(SRoleMenuEntity))]
        public virtual List<SMenuEntity> Menus { get; set; } = new List<SMenuEntity>();
     
    }
}
