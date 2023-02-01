namespace MammasKitchen.Web.Controllers
{
    using System.Diagnostics;

    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Web.ViewModels;
    using MammasKitchen.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var randomProducts = this.productService.GetRandom<ProductInListViewModel>(6);
            var viewModel = new TopProductsViewModel
            {
                RandomProducts = randomProducts,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
