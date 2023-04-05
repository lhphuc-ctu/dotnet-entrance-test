using dotnet_entrance_test.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace dotnet_entrance_test.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
