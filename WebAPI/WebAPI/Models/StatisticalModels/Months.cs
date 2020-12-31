using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.StatistícModels
{
    public class Months
    {
        public int Year { get; set; } 
        public decimal[] MonthOfYearTotal { get; set; }

        public Months()
        {
            this.MonthOfYearTotal = new decimal[12];
        }

        public Months(int year)
        {
            this.Year = year;
            this.MonthOfYearTotal = new decimal[12];
        }
    }
}
