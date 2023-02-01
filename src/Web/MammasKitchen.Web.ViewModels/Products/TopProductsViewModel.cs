namespace MammasKitchen.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class TopProductsViewModel
    {
        public IEnumerable<ProductInListViewModel> RandomProducts { get; set; }
    }
}
