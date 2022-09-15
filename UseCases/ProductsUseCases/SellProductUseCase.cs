using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IRecordTransactionUseCase recordTransactionUseCase;

        public SellProductUseCase(
            IProductRepository productRepository,
            IRecordTransactionUseCase recordTransactionUseCase)
        {
            this.productRepository = productRepository;
            this.recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(int productId, int quantityToSell, string cashierName)
        {
            var product = productRepository.GetProductById(productId);
            if (product == null) return;

            product.Quantity -= quantityToSell;
            productRepository.UpdateProduct(product);
            recordTransactionUseCase.Execute(productId, product.Quantity.Value + quantityToSell, quantityToSell, cashierName);
        }
    }
}
