﻿namespace MammasKitchen.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MammasKitchen.Data.Common.Repositories;
    using MammasKitchen.Data.Models;
    using MammasKitchen.Services.Data.Interfaces;
    using MammasKitchen.Services.Mapping;
    using MammasKitchen.Web.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(
            IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<TModel>> GetCategoriesAsync<TModel>()
         => await this.categoryRepository
            .AllAsNoTracking()
            .To<TModel>()
            .ToListAsync();

        public async Task AddCategoryAsync(CategoryInputModel inputModel)
        {
            var category = new Category
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
            };

            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();
        }
    }
}
