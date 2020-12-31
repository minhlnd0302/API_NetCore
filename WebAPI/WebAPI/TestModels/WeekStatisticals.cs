using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class WeekStatisticals
    {
        public WeekStatisticals()
        {
            DayStatisticals = new HashSet<DayStatisticals>();
        }

        public long Id { get; set; }
        public int? Week { get; set; }
        public long? MonthId { get; set; }
        public long? YearId { get; set; }
        public decimal? TotalWeek { get; set; }

        public virtual MonthStatisticals Month { get; set; }
        public virtual YearStatisticals Year { get; set; }
        public virtual ICollection<DayStatisticals> DayStatisticals { get; set; }
    }
}
