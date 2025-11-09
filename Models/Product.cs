using System;
using System.Collections.Generic;

#nullable disable

namespace AspSooQcom.Models
{
    public partial class Product
    {
        public Product()
        {
            AddorderDeatils = new HashSet<AddorderDeatil>();
            Carts = new HashSet<Cart>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public int? CatId { get; set; }
        public string SupplierName { get; set; }
        public DateTime? DateSystem { get; set; }
        public int? Quantity { get; set; }

        public virtual Catogry Cat { get; set; }
        public virtual ICollection<AddorderDeatil> AddorderDeatils { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
