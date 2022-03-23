using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PerfumeryEfirr.Data
{
    public class Perfumes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; }

        public string Photo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string Description { get; set; }
        public int DateRegister { get; set; }
        public Type Type { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Promotions> Promotions { get; set; }


    }
}
