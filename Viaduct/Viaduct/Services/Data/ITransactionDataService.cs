using System.Collections.Generic;
using System.Threading.Tasks;
using Viaduct.Models;

namespace Viaduct.Services.Data
{
    public interface ITransactionService
    {
        Task<List<Transaction>> ReadAllTransactionsAsync();

        Task<List<User>> ReadAllUsersAsync();

        Task<User> ReadUserAsync(string id);

        Task<User> GetUserByLogin(string login);

        Task DeleteUserAsync(string id);
    }
}