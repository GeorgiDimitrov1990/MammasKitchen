namespace MammasKitchen.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using MammasKitchen.Web.ViewModels.Products;

    public interface IProductService
    {
        Task AddProduct(ProductInputModel inputModel, string imagePath, string userId);
    }
}
