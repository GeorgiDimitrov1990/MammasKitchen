namespace MammasKitchen.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MammasKitchen.Web.ViewModels.Products;

    public interface IProductService
    {
        Task AddProduct(ProductInputModel inputModel, string imagePath, string userId);

        Task<IEnumerable<T>> GetItemsPerPageAsync<T>(int page, int itemsPerPage = 12);

        int GetCount();

        T GetById<T>(string id);

        IEnumerable<T> GetTopProducts<T>();

        IEnumerable<T> GetRandom<T>(int count);
    }
}
