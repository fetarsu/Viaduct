using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Viaduct.Models;

namespace Viaduct.Services.Data
{
    public interface IUserService
    {
        Task SaveUserAsync(User item, bool newItem);
    }
}
