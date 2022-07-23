using System;
using System.Collections.Generic;
using System.Text;
using Viaduct.Models;

namespace Viaduct.Services.Implementation
{
    class LoggedUserService : ILoggedUserService
    {
        public User loggedUser { get ; set; }
    }
}
