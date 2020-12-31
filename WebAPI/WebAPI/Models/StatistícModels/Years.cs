using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.StatistícModels
{
    public class Years
    {
        public int Year { get; set; }
        public decimal YearTotal { get; set; }

        public Years(int year)
        {
            this.Year = year;
            this.YearTotal = 0;
        }
        
    }
}
