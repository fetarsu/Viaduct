using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Viaduct.Models;

namespace Viaduct.Services.Data
{
    public interface IUserDataService
    {
        Task SaveUserAsync(User item, bool newItem);

        Task<List<User>> ReadAllUsersAsync();

        Task<User> ReadUserAsync(string id);

        Task<User> GetUserByLogin(string login);

        Task DeleteUserAsync(string id);
    }
}
