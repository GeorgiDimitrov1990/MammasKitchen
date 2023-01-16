namespace MammasKitchen.Data.Models
{
    using System;

    using MammasKitchen.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
