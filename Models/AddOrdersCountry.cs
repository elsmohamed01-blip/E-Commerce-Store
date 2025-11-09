using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class AddOrdersCountry
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
        public decimal? Totalprice { get; set; }
        public int? Orderid { get; set; }
        public DateTime? DataTime { get; set; }
        public int? ProductCountryId { get; set; }

        public virtual OrdersCountry Order { get; set; }
        public virtual ProductCountry ProductCountry { get; set; }
    }
}
