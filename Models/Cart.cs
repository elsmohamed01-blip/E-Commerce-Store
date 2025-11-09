using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }

        public virtual Product Product { get; set; }
    }
}
