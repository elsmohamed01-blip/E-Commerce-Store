using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspSooQcom.Models
{
    public class ProductCountryVM
    {
        public ProductCountryVM()
        {
            productCountrys = new List<ProductCountry>();
            Categories = new List<CatoegriesCountry>();

        }
        public string Country { get; set; }
        public List<ProductCountry> productCountrys { get; set; }
        public List<CatoegriesCountry> Categories { get; set; }

    }
}
