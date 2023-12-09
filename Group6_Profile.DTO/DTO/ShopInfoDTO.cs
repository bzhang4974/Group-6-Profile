using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    public class ShopInfoDTO : BaseEditDTO
    {
        public string ShopName
        {
            get;
            set;
        }
        public string RegisterDate
        {
            get;
            set;
        }
        public string Describe
        {
            get;
            set;
        }
        public long? SellerId
        {
            get;
            set;
        }
    }
}
