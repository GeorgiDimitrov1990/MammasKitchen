namespace MammasKitchen.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : AdministrationController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.productService.AddProduct(inputModel);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
