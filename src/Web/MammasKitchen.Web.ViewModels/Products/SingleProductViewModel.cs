namespace MammasKitchen.Web.ViewModels.Products
{
    using System.Linq;

    using AutoMapper;
    using MammasKitchen.Data.Models;
    using MammasKitchen.Services.Mapping;

    public class SingleProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string SKU { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, SingleProductViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x =>
                    x.Images.FirstOrDefault().RemoteImageUrl
                    ?? "/images/products/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
