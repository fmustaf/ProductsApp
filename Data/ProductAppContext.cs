using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductApp.Models
{
    public class ProductAppContext : DbContext
    {
        public ProductAppContext (DbContextOptions<ProductAppContext> options)
            : base(options)
        {
        }

        public DbSet<ProductApp.Models.Product> Products { get; set; }
    }
}
