using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DictionaryDbContext : DbContext
    {
        public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options) : base(options) { }

        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<Definition> Definition { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Term);
                entity.Property(e => e.Date);
            });

            modelBuilder.Entity<Word>().HasMany(c => c.Definition).WithOne(e => e.Word).HasForeignKey(e => e.WordId);

            modelBuilder.Entity<Definition>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description);
            });
        }
    }
}
