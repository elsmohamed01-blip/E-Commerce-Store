using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class Catogry
    {
        public Catogry()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
