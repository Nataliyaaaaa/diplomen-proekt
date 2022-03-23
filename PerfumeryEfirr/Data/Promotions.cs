using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfumeryEfirr.Data
{
    public class Promotions
    {

        public int Id { get; set; }

        public int PercentPromotions { get; set; }

        public int IdPerfume { get; set; }

        public int DateBegin { get; set; }

        public int DateEnd { get; set; }

    }
}
