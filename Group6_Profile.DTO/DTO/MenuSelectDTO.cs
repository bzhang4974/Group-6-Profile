using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    /// <summary>
    /// Menu Select DTO
    /// </summary>
    public class MenuSelectDTO
    {
        /// <summary>
        /// Menu Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Menu Order Index
        /// </summary>
        public string OrderIndex { get; set; }
        /// <summary>
        /// Menu Name
        /// </summary>
        public string Name { get; set; }
    }
}
