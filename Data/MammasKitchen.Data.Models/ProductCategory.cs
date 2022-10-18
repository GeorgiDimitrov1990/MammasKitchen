namespace MammasKitchen.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MammasKitchen.Data.Common.Models;

    public class ProductCategory : BaseDeletableModel<string>
    {
        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Subcategories = new HashSet<ProductSubcategory>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TestId { get; set; }

        public virtual ICollection<ProductSubcategory> Subcategories { get; set; }
    }
}
