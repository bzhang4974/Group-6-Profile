using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    public class ProductDTO
    {
        /// The product ID formatted as (P0000...).
        public string pid { get; set; }

        /// The seller ID formatted as (S0000...).
        public string sid { get; set; }

        /// The product name.
        public string name { get; set; }

        /// The product description.
        public string description { get; set; }

        /// The product image as a URL.
        public string image { get; set; }

        /// The product category.
        public string category { get; set; }

        /// The product price.
        public float price { get; set; }

        /// The product stock level.
        public int stock { get; set; }

        /// The product total number of sales.
        public int sales { get; set; }

        /// The product rating using a five-star system.
        public float rating { get; set; }

        /// The product number of clicks.
        public float clicks { get; set; }
    }
}
