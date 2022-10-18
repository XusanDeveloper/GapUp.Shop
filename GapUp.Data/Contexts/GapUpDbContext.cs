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

        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
