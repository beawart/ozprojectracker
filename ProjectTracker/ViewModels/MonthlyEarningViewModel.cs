using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.ViewModels
{
    public class MonthlyEarningViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Earning { get; set; }
    }
}
