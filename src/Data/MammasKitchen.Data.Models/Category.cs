namespace MammasKitchen.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MammasKitchen.Data.Common.Models;

    public class Category : BaseDeletableModel<string>
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Subcategories = new HashSet<ProductSubcategory>();
            this.Products = new HashSet<Product>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<ProductSubcategory> Subcategories { get; set; }
    }
}
