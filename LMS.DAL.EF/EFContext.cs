using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Testing.LMS.Models;

namespace Testing.LMS.DAL.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : base() { }

        public DbSet<BookEntity> Book { get; set; }
        public DbSet<UserEntity> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=AHMEDPC\MSSQLSERVER02;Initial Catalog=Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
