using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using react.Models;

namespace react_backend
{
    public class LinkedinContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=linkedin;Trusted_Connection=True;");
        }

        public DbSet<Experience> Experiencies { get; set; } 
        public DbSet<Education> Education { get; set; }
        public DbSet<Honor> Honors { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>()
            .ToTable("Experience");
            modelBuilder.Entity<Education>()
            .ToTable("Education");
            modelBuilder.Entity<Honor>()
            .ToTable("Honors");
            modelBuilder.Entity<Languages>()
            .ToTable("Languages");
            modelBuilder.Entity<Skill>()
            .ToTable("Skills");
            modelBuilder.Entity<User>()
            .ToTable("Users");

            // // mapping işlemi
            // modelBuilder.Entity<Experience>()
            // .HasOne(t => t.User)
            // .WithMany(x => x.Experiencies)
            // .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<User>()
            .HasMany(x=> x.Experiencies)
            .WithOne(x=> x.User)
            .HasForeignKey(x=>x.UserId);
            
            // modelBuilder.Entity<User>()
            // .Property(x => x.Id)
            // .HasColumnName("user_id");

            // modelBuilder.Entity<Experience>()
            // .HasOne(x => x.User)
            // .WithMany(x => x.Experiencies);

            // modelBuilder.Entity<Activities>()
            // .HasOne(x => x.Education)
            // .WithMany(x => x.Activities);

            // modelBuilder.Entity<Education>()
            // .HasOne(x => x.User)
            // .WithMany(x => Education);

            // modelBuilder.Entity<Honor>()
            // .HasOne(x => x.User)
            // .WithMany(x => x.Honors);

            // modelBuilder.Entity<Languages>()
            // .HasOne(x => x.User)
            // .WithMany(x => x.Languages);

            // modelBuilder.Entity<Skill>()
            // .HasOne(x=>x.User)
            // .WithMany(x=>x.Skills);
        }
    }
}