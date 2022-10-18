namespace MammasKitchen.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MammasKitchen.Data.Common.Models;

    public class Product : BaseDeletableModel<string>
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ProductCategory = new HashSet<ProductCategory>();
        }

        public string Description { get; set; }

        public string SKU { get; set; }

        public decimal Price { get; set; }

        public string SubcategoryId { get; set; }

        public virtual ProductSubcategory Subcategory { get; set; }

        public string DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual CartItem CartItem { get; set; }

        public virtual OrderItem OrderItem { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
