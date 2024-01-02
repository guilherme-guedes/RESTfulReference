﻿using Microsoft.EntityFrameworkCore;
using RestfulReference.Domain.Entities;

namespace RestfulReference.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
