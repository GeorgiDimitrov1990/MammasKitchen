namespace MammasKitchen.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MammasKitchen.Data.Common.Repositories;
    using MammasKitchen.Data.Models;
    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Services.Mapping;
    using MammasKitchen.Web.ViewModels.Products;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : IProductService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly IRepository<Vote> votesRepository;

        public ProductService(
            IDeletableEntityRepository<Category> categoryRepository,
            IDeletableEntityRepository<Product> productRepository,
            IRepository<Vote> votesRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.votesRepository = votesRepository;
        }

        public async Task AddProduct(ProductInputModel inputModel, string imagePath, string userId)
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

            // Creating directory and adding image
            Directory.CreateDirectory($"{imagePath}/products/");

            if (inputModel.Images != null)
            {
                foreach (var image in inputModel.Images)
                {
                    var extension = Path.GetExtension(image.FileName).TrimStart('.');
                    if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                    {
                        throw new Exception($"Invalid image extension {extension}");
                    }

                    var dbImage = new Image
                    {
                        AddedByUserId = userId,
                        Extension = extension,
                    };

                    newProduct.Images.Add(dbImage);

                    var physicalPath = $"{imagePath}/products/{dbImage.Id}.{extension}";
                    using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.productRepository.AddAsync(newProduct);
            await this.productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetItemsPerPageAsync<T>(int page, int itemsPerPage = 12)
        {
            return await this.productRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();
        }

        public int GetCount()
        => this.productRepository.AllAsNoTracking().Count();

        public T GetById<T>(string id)
        => this.productRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

        public IEnumerable<T> GetTopProducts<T>()
        {
            var topProductsIds = this.votesRepository
                .All()
                .GroupBy(x => x.ProductId)
                .OrderByDescending(x => x.Average(y => y.Value))
                .Take(6).Select(x => x.First().ProductId)
                .ToList();

            return this.productRepository
                .AllAsNoTracking()
                .Where(x => topProductsIds.Any(y => x.Id == y))
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.productRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .To<T>().ToList();
        }
    }
}
