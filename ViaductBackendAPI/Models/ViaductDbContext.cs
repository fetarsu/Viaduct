﻿using Microsoft.EntityFrameworkCore;

namespace ViaductBackendAPI.Models
{
    public class ViaductDbContext : DbContext
    {
        public ViaductDbContext(DbContextOptions<ViaductDbContext> options)
            : base(options)
        {
        }

        public DbSet<ViaductBackendAPI.Models.User> User { get; set; }
        public DbSet<ViaductBackendAPI.Models.Report> Report { get; set; }
        public DbSet<ViaductBackendAPI.Models.Transaction> Transaction { get; set; }
    }
}
