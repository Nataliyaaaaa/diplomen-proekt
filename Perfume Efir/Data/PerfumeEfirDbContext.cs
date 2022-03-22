using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfume_Efir.Data
{
    public class PerfumeEfirDbContext : DbContext
    {
         public PerfumeEfirDbContext()

        {

        }

        public PerfumeEfirDbContext(DbContextOptions<PerfumeEfirDbContext> option) : base(option)
        {

        }
        
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        private DbSet<Product> Products { get; set; }
    
     
    
    }
}
