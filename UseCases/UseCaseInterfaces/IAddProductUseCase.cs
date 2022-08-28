using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.UseCaseInterfaces
{
    public interface IAddProductUseCase
    {
        void Execute(Product product);
    }
}