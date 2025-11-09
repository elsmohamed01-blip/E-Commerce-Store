using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class CartTotal
    {
        public int Id { get; set; }
        public int? Totalquantity { get; set; }
        public decimal? Totalprice { get; set; }
        public int? CartId { get; set; }
    }
}
