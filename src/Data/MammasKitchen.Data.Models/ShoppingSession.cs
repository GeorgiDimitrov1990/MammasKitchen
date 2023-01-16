namespace MammasKitchen.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using MammasKitchen.Data.Common.Models;

    public class ShoppingSession : BaseModel<string>
    {
        public ShoppingSession()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CartItems = new HashSet<CartItem>();
        }

        public decimal Total { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
