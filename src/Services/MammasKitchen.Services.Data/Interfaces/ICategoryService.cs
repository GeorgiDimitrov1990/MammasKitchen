namespace MammasKitchen.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MammasKitchen.Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<TModel>> GetCategoriesAsync<TModel>();

        Task AddCategoryAsync(CategoryInputModel inputModel);
    }
}
