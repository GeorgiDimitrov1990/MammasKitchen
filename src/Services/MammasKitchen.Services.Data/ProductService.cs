namespace MammasKitchen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MammasKitchen.Data;
    using MammasKitchen.Data.Common.Repositories;
    using MammasKitchen.Data.Models;
    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Services.Mapping;
    using MammasKitchen.Web.ViewModels.Products;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<Product> productRepository;

        public ProductService(
            IDeletableEntityRepository<Category> categoryRepository,
            IDeletableEntityRepository<Product> productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public async Task AddProduct(ProductInputModel inputModel)
        {
            var categories = await this.categoryRepository.All()
                .Where(x => inputModel.CategoriesId.Any(y => x.Id == y)).ToListAsync();

            var newProduct = new Product
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                Price = inputModel.Price,
                Categories = categories,
            };

            await this.productRepository.AddAsync(newProduct);
            await this.productRepository.SaveChangesAsync();
        }
    }
}
