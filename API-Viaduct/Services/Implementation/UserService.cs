using API_Viaduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.MobileServices;

namespace API_Viaduct.Services.Implementation
{
    public class UserService : IUserService
    {
        private static readonly MobileServiceClient azureService = new MobileServiceClient("https://viaductmobile.azurewebsites.net/");

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var xa = await azureService.GetTable<User>().ToListAsync();
                return xa;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetUser(int userId)
        {
            var table = azureService.GetTable<User>();
            var query = table.Where(x => x.UserId == userId);
            return await table.ReadAsync(query);
        }

        public async Task<User> UpdateUser(User user)
        {
            var table = azureService.GetTable<User>();
            await table.UpdateAsync(user);
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            var table = azureService.GetTable<User>();
            await table.InsertAsync(user);
            return user;
        }

        public async Task<User> DeleteUser(User user)
        {
            var table = azureService.GetTable<User>();
            await table.DeleteAsync(user);
            return user;
        }
    }
}
