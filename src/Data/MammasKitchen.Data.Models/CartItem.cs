namespace MammasKitchen.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MammasKitchen.Data.Common.Models;

    public class CartItem : BaseModel<string>
    {
        public CartItem()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string ShoppingSessionId { get; set; }

        public virtual ShoppingSession ShoppingSession { get; set; }
    }
}
