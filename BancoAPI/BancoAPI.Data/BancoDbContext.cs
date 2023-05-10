using BancoAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPI.Data
{
    public class BancoDbContext : DbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }

        public BancoDbContext(DbContextOptions<BancoDbContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.FullName.StartsWith("BancoAPI.Data", StringComparison.OrdinalIgnoreCase));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
