using ViaductAPI.Models;

namespace ViaductAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetUser(string userId);
        Task<User> UpdateUser(User user);
        Task<User> AddUser(User user);
        Task<User> DeleteUser(User user);
    }
}
