namespace MammasKitchen.Data.Models
{
    using System;

    using MammasKitchen.Data.Common.Models;

    public class UserAddress : BaseModel<string>
    {
        public UserAddress()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Telephone { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
