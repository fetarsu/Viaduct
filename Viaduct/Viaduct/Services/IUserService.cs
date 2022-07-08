using System;
using System.Collections.Generic;
using System.Text;
using Viaduct.Models;

namespace Viaduct.Services
{
    interface IUserService
    {
        User loggedUser { get; set; }
    }
}
