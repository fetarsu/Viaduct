using System.Collections.Generic;
using System.Threading.Tasks;
using Viaduct.Models;

namespace Viaduct.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetUser(string userId);
        Task<User> UpdateUser(User user);
        Task<User> AddUser(User user);
    }
}