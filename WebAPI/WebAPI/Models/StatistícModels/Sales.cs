using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.StatistícModels
{
    public class Sales
    {
        public List<Weeks> Weekss { get; set; }
        public List<Months> Monthss { get; set; }
        public List<Years> Yearss { get; set; }

        public Sales()
        {
            Weekss = new List<Weeks>();
            Monthss = new List<Months>();
            Yearss = new List<Years>(); 
        }  
        async public Task<Sales> Calculator() 
        {
             
            var _context = new TGDDContext();
            List<Order> orders = await _context.Orders.ToListAsync();

            var week = new int();
            var month = new int();
            var year = new int();

            var indexWeekofListWeek = new int();
            var indexMonthOfListMonth = new int();
            var indexYearOfListYear = new int();

            foreach (Order order in orders)
            {
                week = (int)order.Date.Value.DayOfYear / 7 - 1;
                month = order.Date.Value.Month;
                year = order.Date.Value.Year;

                indexWeekofListWeek = WeekOfYearExist(year);
                indexMonthOfListMonth = MonthOfYearExist(year);
                indexYearOfListYear = YearExist(year);

                decimal total = order.Total;

                List<int> tmp = new List<int>();

                if (indexWeekofListWeek != -1)
                {
                    this.Weekss[indexWeekofListWeek].WeekOfYearTotal[week] += total;
                }
                else
                { 
                    this.Weekss.Add(new Weeks(year)); 
                    this.Weekss[(this.Weekss.Count -1)].WeekOfYearTotal[week] += total;
                }

                if (indexMonthOfListMonth != -1)
                {
                    this.Monthss[indexMonthOfListMonth].MonthOfYearTotal[month] += total;
                }
                else
                {
                    this.Monthss.Add(new Months(year));
                    this.Monthss[(this.Monthss.Count -1)].MonthOfYearTotal[month] += total;
                }


                if (indexYearOfListYear != -1)
                {
                    this.Yearss[indexYearOfListYear].YearTotal += total;
                }
                else
                {
                    this.Yearss.Add(new Years(year));
                    this.Yearss[(this.Yearss.Count - 1)].YearTotal += total;
                } 
            }

            return this;
        } 
        private int WeekOfYearExist(int year)
        {
            int i = -1;
            if (this.Weekss == null) return i;
            foreach(Weeks weeks in this.Weekss)
            {
                i++;
                if (weeks.Year == year)
                {
                    return i;
                } 
            }
            return -1;
        } 
        private int MonthOfYearExist(int year)
        {
            int i = -1;
            if (this.Monthss == null) return i;
            foreach(Months months in this.Monthss)
            {
                if (months.Year == year) return i; ;
            }
            return -1;
        }
        private int YearExist(int year)
        {
            int i = -1;
            if (this.Yearss == null) return i;
            foreach(Years years in this.Yearss)
            {
                i++;
                if (years.Year == year) return i;
            }
            return -1;
        }
    }
}
