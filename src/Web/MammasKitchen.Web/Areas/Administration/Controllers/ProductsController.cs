namespace MammasKitchen.Web.Areas.Administration.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : AdministrationController
    {
        private readonly IProductService productService;
        private readonly IWebHostEnvironment environment;

        public ProductsController(
            IProductService productService,
            IWebHostEnvironment environment)
        {
            this.productService = productService;
            this.environment = environment;
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

            var imagePath = $"{this.environment.WebRootPath}/images";
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.productService.AddProduct(inputModel, imagePath, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
