using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class DayStatisticals
    {
        public long Id { get; set; }
        public int? Day { get; set; }
        public long? WeekId { get; set; }
        public long? MonthId { get; set; }
        public long? YearId { get; set; }
        public decimal? TotalDay { get; set; }

        public virtual MonthStatisticals Month { get; set; }
        public virtual WeekStatisticals Week { get; set; }
        public virtual YearStatisticals Year { get; set; }
    }
}
