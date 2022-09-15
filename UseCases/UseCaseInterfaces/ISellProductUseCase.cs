namespace UseCases.UseCaseInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(int productId, int quantityToSell, string cashierName);
    }
}