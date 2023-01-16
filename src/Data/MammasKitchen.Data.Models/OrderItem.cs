namespace MammasKitchen.Data.Models
{
    using System;

    using MammasKitchen.Data.Common.Models;

    public class OrderItem : BaseModel<string>
    {
        public OrderItem()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string OrderDetailId { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
