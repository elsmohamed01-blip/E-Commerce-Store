using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspSooQcom.Models
{
    public class IndexVM
    {
        public IndexVM()
        {
            Cateogries = new List<Catogry>();
            Products = new List<Product>();
            Reviews = new List<Review>();
            LatesProducts = new List<Product>();
            country = new List<ProductCountry>();
        }
        public List<Catogry> Cateogries { get; set; }
        public List<Product> LatesProducts { get; set; }
        public List<Product> Products { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ProductCountry> country { get; set; }
    }
}