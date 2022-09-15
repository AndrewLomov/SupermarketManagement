namespace UseCases.UseCaseInterfaces
{
    public interface IRecordTransactionUseCase
    {
        void Execute(int productId, int beforeQuantity, int soldQuantity, string cashierName);
    }
}