﻿using System.ComponentModel.DataAnnotations;

namespace ViaductAPI.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
    }
}
