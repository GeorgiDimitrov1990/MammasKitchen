namespace MammasKitchen.Web.ViewComponents
{
    using System.Threading.Tasks;

    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Web.ViewModels.Common;
    using Microsoft.AspNetCore.Mvc;

    public class SelectCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public SelectCategoryViewComponent(
            ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = this.categoryService.GetCategoriesAsync<SelectViewModel>().GetAwaiter().GetResult();

            return this.View(viewModel);
        }
    }
}
