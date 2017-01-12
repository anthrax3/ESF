using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Intime.Framework.Repository.EF.UnitTest.Models;

namespace Intime.Framework.Repository.EF.UnitTest
{
    public class DemoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("EF_Test_User");
            modelBuilder.Entity<User>()
                .HasKey(v => v.Id)
                .Property(v => v.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().HasMany(m => m.Logs).WithRequired(m => m.User).HasForeignKey(m => m.UserId);
            modelBuilder.Entity<User>().Property(v => v.LastChanged).IsConcurrencyToken().IsRowVersion();
            
            modelBuilder.Entity<Log>().ToTable("EF_Test_Log");
            modelBuilder.Entity<Log>().Property(v => v.UserId).HasColumnName("UserId");
            modelBuilder.Entity<Log>().HasKey(v => v.Id);
            modelBuilder.Entity<Log>().Property(v => v.ActionName).HasMaxLength(5);
            //modelBuilder.Entity<Log>().HasRequired(v => v.User).WithMany(m => m.Logs).HasForeignKey(v => v.UserId);
        }

        public DemoDbContext(string dbName) : base(dbName) 
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DemoDbContext() 
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("EF_Test_User");
            modelBuilder.Entity<User>()
                .HasKey(v => v.Id)
                .Property(v => v.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().Property(v => v.LastChanged).IsConcurrencyToken().IsRowVersion();
        }

        public UserDbContext(string dbName) : base(dbName) 
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public UserDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }

    public class LogDbContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().ToTable("EF_Test_Log");
            modelBuilder.Entity<Log>().Property(v => v.UserId).HasColumnName("UserId");
            modelBuilder.Entity<Log>().HasKey(v => v.Id);
            modelBuilder.Entity<Log>().Property(v => v.ActionName).HasMaxLength(50);
            modelBuilder.Entity<Log>().HasRequired(v => v.User).WithMany().HasForeignKey(v => v.UserId);
        }

        public LogDbContext(string dbName) : base(dbName) 
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public LogDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
