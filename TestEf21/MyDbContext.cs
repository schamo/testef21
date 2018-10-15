using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestEf21
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<ParentEntity> Parents { get; set; }

        public virtual DbSet<ChildEntity> Children { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestEf21;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentEntity>().HasData(
                new ParentEntity
                {
                    Key = 1,
                    Name = "Object1"
                },
                new ParentEntity
                {
                    Key = 2,
                    Name = "Object2"
                });
            modelBuilder.Entity<ChildEntity>().HasData(
                new ChildEntity
                {
                    Key = 1,
                    ParentKey = 1,
                    CanView = true
                },
                new ChildEntity
                {
                    Key = 2,
                    ParentKey = 1,
                    CanView = false
                },
                new ChildEntity
                {
                    Key = 3,
                    ParentKey = 2,
                    CanView = false
                },
                new ChildEntity
                {
                    Key = 4,
                    ParentKey = 2,
                    CanView = false
                });
        }
    }
}
