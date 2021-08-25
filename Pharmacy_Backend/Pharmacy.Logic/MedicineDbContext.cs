using Microsoft.EntityFrameworkCore;
using Pharmacy.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Logic
{
    public class MedicineDbContext: DbContext
    {
        private readonly string _ConnectionString;

        public MedicineDbContext(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString, options => options.EnableRetryOnFailure());
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Medicine>(eb => eb.HasNoKey());
        //}

        #region DataSets
        public DbSet<Medicine> Medicine { get; set; }
        #endregion DataSets
    }
}
