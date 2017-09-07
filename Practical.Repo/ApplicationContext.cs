using Microsoft.EntityFrameworkCore;
using Practical.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Repo
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UService> UService { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<UService>(entity => {
                entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<UserService>()
                .HasKey(bc => new { bc.UserId, bc.ServiceId });

            modelBuilder.Entity<UserService>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserServices)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserService>()
                .HasOne(bc => bc.Service)
                .WithMany(c => c.UserServices)
                .HasForeignKey(bc => bc.ServiceId);
        }
    }
}
