using GapUp.Domain.Configuration;
using GapUp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapUp.Domain.Contexts
{
    public class GapUpDbContext : DbContext
    {
        public GapUpDbContext(DbContextOptions<GapUpDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        public DbSet<Product> Products { get; set; }
    }
}
