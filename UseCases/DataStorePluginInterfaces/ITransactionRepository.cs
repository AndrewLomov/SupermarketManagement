using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> Get(string cashierName);
        IEnumerable<Transaction> GetByDay(DateTime date, string cashierName);
        void Save(int productId, string productName, double price, int beforeQuantity, int soldQuantity, string cashierName);
    }
}
