using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductByIdUseCase getProductByIdUseCase;

        public RecordTransactionUseCase(
            ITransactionRepository transactionRepository,
            IGetProductByIdUseCase getProductByIdUseCase)
        {
            this.transactionRepository = transactionRepository;
            this.getProductByIdUseCase = getProductByIdUseCase;
        }

        public void Execute(int productId, int beforeQuantity, int soldQuantity, string cashierName)
        {
            var product = getProductByIdUseCase.Execute(productId);
            transactionRepository.Save(productId, product.Name, product.Price.Value, beforeQuantity, soldQuantity, cashierName);
        }
    }
}
