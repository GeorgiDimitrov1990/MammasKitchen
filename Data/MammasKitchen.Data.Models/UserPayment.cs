namespace MammasKitchen.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MammasKitchen.Data.Common.Models;

    public class UserPayment : BaseModel<string>
    {
        public UserPayment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string PaymentType { get; set; }

        public string Provider { get; set; }

        public DateTime Expiry { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
