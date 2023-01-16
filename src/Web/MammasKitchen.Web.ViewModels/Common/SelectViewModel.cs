namespace MammasKitchen.Web.ViewModels.Common
{
    using MammasKitchen.Data.Models;
    using MammasKitchen.Services.Mapping;

    public class SelectViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
