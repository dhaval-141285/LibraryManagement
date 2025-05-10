using System.Reflection;
using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}