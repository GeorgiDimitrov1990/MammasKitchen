namespace MammasKitchen.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class ProductInputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<string> CategoriesId { get; set; }

        public string SubCategoryId { get; set; }
    }
}
