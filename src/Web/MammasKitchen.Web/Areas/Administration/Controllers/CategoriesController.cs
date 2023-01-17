namespace MammasKitchen.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.categoryService.AddCategoryAsync(inputModel);

            return Ok();
        }
    }
}
