using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Entity
{
    [Table(Name = "S_User")]
    internal class SUserEntity : BaseEntity
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

        public string PassWord { get; set; }
        /// <summary>
        /// Num
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// Tel
        /// </summary>

        public string Tel { get; set; }
        /// <summary>
        /// IsDelete
        /// </summary>
        public bool IsDelete { get; set; }
        //// <summary>
        ///  
        /// </summary>
        [Navigate(ManyToMany = typeof(SUserRoleEntity))]
        public virtual List<SRoleEntity> Roles { get; set; } = new List<SRoleEntity>();

    }
}
