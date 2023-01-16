namespace MammasKitchen.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MammasKitchen.Data.Models;
    using MammasKitchen.Web.ViewModels.Products;

    public interface IProductService
    {
        Task AddProduct(ProductInputModel inputModel);
    }
}
