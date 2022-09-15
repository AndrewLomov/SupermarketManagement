using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;

        public TransactionInMemoryRepository()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactions;
            }
            return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetByDay(DateTime date, string cashierName)
        {
            var transactionsTimeStamp = transactions.Where(x => x.TimeStamp.Date == date.Date);
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactionsTimeStamp;
            }
            return transactionsTimeStamp.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public void Save(int productId, string productName, double price, int beforeQuantity, int soldQuantity, string cashierName)
        {
            int transactionId = 0;
            if (transactions != null && transactions.Count > 0)
            {
                int maxId = transactions.Max(x => x.TransactionId);
                transactionId = ++maxId;
            }

            transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                CashierName = cashierName
            });
        }
    }
}
