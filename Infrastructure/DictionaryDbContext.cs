using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class DictionaryDbContext : DbContext
    {
        public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options) : base(options) { }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<Definition> Definition { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
