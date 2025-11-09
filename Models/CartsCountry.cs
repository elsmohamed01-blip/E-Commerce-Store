using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class CartsCountry
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? ProductCountryId { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }

        public virtual ProductCountry ProductCountry { get; set; }
    }
}
