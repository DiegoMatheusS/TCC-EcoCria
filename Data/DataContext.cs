using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace TCCEcoCria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Nomedamodel> TB_nomedamodel { get; set; }

        protected override void OodelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nomedamodel>().ToTable("TB_NOMEDAMODEL");
        }

    }
}