namespace MammasKitchen.Web.Controllers
{
    using System.Threading.Tasks;

    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id < 0)
            {
                return this.NotFound();
            }

            var itemsPerPage = 12;
            var products = await this.productService.GetItemsPerPageAsync<ProductInListViewModel>(id, itemsPerPage);

            var viewModel = new ProductListViewModel
            {
                Products = products,
                PageNumber = id,
                ProductsCount = this.productService.GetCount(),
                ItemsPerPage = itemsPerPage,
            };

            return this.View(viewModel);
        }
    }
}
