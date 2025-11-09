using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class CatoegriesCountry
    {
        public CatoegriesCountry()
        {
            ProductCountries = new HashSet<ProductCountry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }

        public virtual ICollection<ProductCountry> ProductCountries { get; set; }
    }
}
