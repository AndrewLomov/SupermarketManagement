using CoreBusiness;
using System;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;
using System.Linq;

namespace Plugins.DataStore.InMemory
{
    //InMemory data store for rapid development, then swap it with SQL
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            //Add some default categories
            categories = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage"},
                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery"},
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat"},
            };
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            int maxId = categories.Max(x => x.CategoryId);
            category.CategoryId = ++maxId;

            categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

    }
}
