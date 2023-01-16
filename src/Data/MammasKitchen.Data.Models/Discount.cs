namespace MammasKitchen.Data.Models
{
    using System;

    using MammasKitchen.Data.Common.Models;

    public class Discount : BaseModel<string>
    {
        public Discount()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal DiscountPercent { get; set; }

        public bool IsActive { get; set; }

        public virtual Product Product { get; set; }
    }
}
