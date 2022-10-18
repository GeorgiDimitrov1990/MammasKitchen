namespace MammasKitchen.Data.Models
{
    using System;

    using MammasKitchen.Data.Common.Models;

    public class PaymentDetail : BaseModel<string>
    {
        public PaymentDetail()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int Amount { get; set; }

        public string Provider { get; set; }

        public string Status { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
