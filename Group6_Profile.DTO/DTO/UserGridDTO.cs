using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// User Table DTO
    /// </summary>
    public class UserGridDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        ///  UserName
        /// </summary>

        public string UserName { get; set; }

        /// <summary>
        /// Tel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Tel
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// IsDelete
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// RoleName
        /// </summary>
        public string RoleName { get; set; }
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
