using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class OrdersCountry
    {
        public OrdersCountry()
        {
            AddOrdersCountries = new HashSet<AddOrdersCountry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Aderss { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserId { get; set; }
        public DateTime? DataTime { get; set; }
        public bool? IsonlineParid { get; set; }

        public virtual ICollection<AddOrdersCountry> AddOrdersCountries { get; set; }
    }
}
