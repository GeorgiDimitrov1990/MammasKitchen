namespace MammasKitchen.Data.Models
{
    using MammasKitchen.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
