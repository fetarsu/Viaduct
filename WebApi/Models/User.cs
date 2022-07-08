using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class User : EntityData
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
    }
}