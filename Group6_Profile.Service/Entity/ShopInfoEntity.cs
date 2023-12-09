using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.Service.Entity
{
    [Table(Name ="S_Shop")]
    public class ShopInfoEntity : BaseEntity
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
