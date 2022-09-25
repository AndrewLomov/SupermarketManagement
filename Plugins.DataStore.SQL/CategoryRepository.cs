using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext _marketContext;

        public CategoryRepository(MarketContext marketContext)
        {
            this._marketContext = marketContext;
        }

        public void AddCategory(Category category)
        {
            _marketContext.Categories.Add(category);
            _marketContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _marketContext.Categories.Find(categoryId);
            if (category == null) return;

            _marketContext.Categories.Remove(category);
            _marketContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _marketContext.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _marketContext.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var cat = _marketContext.Categories.Find(category.CategoryId);
            cat.Name = category.Name;
            cat.Description = category.Description;
            _marketContext.SaveChanges();
        }
    }
}
