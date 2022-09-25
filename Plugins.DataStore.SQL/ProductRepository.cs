using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext _marketContext;
        public ProductRepository(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public void AddProduct(Product product)
        {
            _marketContext.Products.Add(product);
            _marketContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _marketContext.Products.Find(productId);
            if (product == null) return;

            _marketContext.Products.Remove(product);
            _marketContext.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _marketContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _marketContext.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _marketContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = _marketContext.Products.Find(product.ProductId);
            prod.CategoryId = product.CategoryId;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;

            _marketContext.SaveChanges();
        }
    }
}
