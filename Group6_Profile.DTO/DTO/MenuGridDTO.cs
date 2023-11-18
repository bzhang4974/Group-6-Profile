using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// Menu Table Data
    /// </summary>
    public class MenuGridDTO : BaseDTO
    {
        /// <summary>
        /// Menu Order Index
        /// </summary>
        public string OrderIndex { get; set; }
        /// <summary>
        /// Is First Page
        /// </summary>
        public bool IsFirstPage { get; set; }
        /// <summary>
        /// Menu Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Menu Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Menu Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Menu Describe
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// Is Delete
        /// </summary>
        public bool IsDelete { get; set; } = false;
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
