using System;
using System.Collections.Generic;
using System.Text;
using Viaduct.Models;

namespace Viaduct.Services.Implementation
{
    class UserService : IUserService
    {
        public User loggedUser { get ; set; }
    }
}
