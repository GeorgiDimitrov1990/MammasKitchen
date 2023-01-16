namespace MammasKitchen.Data.Models
{
    using System;

    using MammasKitchen.Data.Common.Models;

    public class ProductSubcategory : BaseDeletableModel<string>
    {
        public ProductSubcategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
