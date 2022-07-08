using API_Viaduct.Models;

namespace API_Viaduct.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetUser(int userId);
        Task<User> UpdateUser(User user);
        Task<User> AddUser(User user);
        Task<User> DeleteUser(User user);
    }
}
