using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Viaduct.Models;

namespace Viaduct.Services.Data
{
    public interface ITransactionDataService
    {
        Task<List<Transaction>> ReadAllTransactionsAsync();

        Task<Transaction> ReadTransactionAsync(int id);

        Task<List<Transaction>> ReadTransactionsFromOneDay(string date);

        Task SaveTransactionAsync(Transaction item, bool isNewItem);
    }
}