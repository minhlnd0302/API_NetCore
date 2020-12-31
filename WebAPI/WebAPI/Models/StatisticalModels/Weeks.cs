using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.StatistícModels
{
    public class Weeks
    {
        public int Year { get; set; }
        public decimal[] WeekOfYearTotal { get; set; }
        public Weeks()
        {
            this.WeekOfYearTotal = new decimal[52];
        }

        public Weeks(int year)
        {
            this.Year = year;
            this.WeekOfYearTotal = new decimal[52];
        }

    }
}
