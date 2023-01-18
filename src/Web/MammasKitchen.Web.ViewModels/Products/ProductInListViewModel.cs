namespace MammasKitchen.Web.ViewModels.Products
{
    using System.Linq;

    using AutoMapper;
    using MammasKitchen.Data.Models;
    using MammasKitchen.Services.Mapping;

    public class ProductInListViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x =>
                    x.Images.FirstOrDefault().RemoteImageUrl
                    ?? "/images/products/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension))
                .ForMember(x => x.CategoryName, opt =>
                opt.MapFrom(x =>
                    x.Categories.FirstOrDefault().Name))
                .ForMember(x => x.CategoryId, opt =>
                opt.MapFrom(x =>
                x.Categories.FirstOrDefault().Id));
        }
    }
}
