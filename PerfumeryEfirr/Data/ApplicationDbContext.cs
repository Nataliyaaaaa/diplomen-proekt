using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PerfumeryEfirr.Data;

namespace PerfumeryEfirr.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Perfumes> Perfumes { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Promotions> Promotions { get; set; }



    }
}
