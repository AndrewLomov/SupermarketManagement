using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext _marketContext;

        public TransactionRepository(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _marketContext.Transactions;
            }
            return _marketContext.Transactions.Where(t => t.CashierName == cashierName).ToList();
        }

        public IEnumerable<Transaction> GetByDateRange(DateTime startDate, DateTime endDate, string cashierName)
        {
            var transactionsTimeStamp = _marketContext.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactionsTimeStamp;
            }
            return transactionsTimeStamp.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%"));
        }

        public IEnumerable<Transaction> GetByDay(DateTime date, string cashierName)
        {
            var transactionsTimeStamp = _marketContext.Transactions.Where(x => x.TimeStamp.Date == date.Date);
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactionsTimeStamp;
            }
            return transactionsTimeStamp.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%"));
        }

        public void Save(int productId, string productName, double price, int beforeQuantity, int soldQuantity, string cashierName)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                CashierName = cashierName
            };

            _marketContext.Transactions.Add(transaction);
            _marketContext.SaveChanges();
        }
    }
}
