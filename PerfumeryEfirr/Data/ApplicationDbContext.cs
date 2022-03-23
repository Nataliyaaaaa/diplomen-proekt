using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeryEfirr.Data
{
    public class ApplicationDbContext : IdentityDbContext<Clients>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Perfumes> Perfumes { get; set; }

        public DbSet<Order> Order { get; set; }



    }
}
