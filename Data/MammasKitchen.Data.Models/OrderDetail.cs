namespace MammasKitchen.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MammasKitchen.Data.Common.Models;

    public class OrderDetail : BaseModel<string>
    {
        public OrderDetail()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderItems = new HashSet<OrderItem>();
        }

        public decimal Total { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string PaymentDetailsId { get; set; }

        public virtual PaymentDetail PaymentDetails { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
