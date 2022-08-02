using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewCategoriesUseCase
    {
        public IEnumerable<Category> Execute();
    }
}