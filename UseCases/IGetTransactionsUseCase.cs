using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases
{
    public interface IGetTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(DateTime startDate, DateTime endDate, string cashierName);
    }
}