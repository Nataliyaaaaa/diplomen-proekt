using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfumeryEfirr.Data
{
    public class Clients
    {
        public int Id { get; set; }

        public string IdRole { get; set; }

        public string Telephone { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public RoleType Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }



    }
}
