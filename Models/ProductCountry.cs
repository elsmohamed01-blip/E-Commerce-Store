using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class ProductCountry
    {

        public ProductCountry()
        {
            AddOrdersCountries = new HashSet<AddOrdersCountry>();
            CartsCountries = new HashSet<CartsCountry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public int? Quantity { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public int? CateoId { get; set; }

        public virtual CatoegriesCountry Cateo { get; set; }
        public virtual ICollection<AddOrdersCountry> AddOrdersCountries { get; set; }
        public virtual ICollection<CartsCountry> CartsCountries { get; set; }

      
    }
}
