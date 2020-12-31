using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class YearStatisticals
    {
        public YearStatisticals()
        {
            DayStatisticals = new HashSet<DayStatisticals>();
            MonthStatisticals = new HashSet<MonthStatisticals>();
            WeekStatisticals = new HashSet<WeekStatisticals>();
        }

        public long Id { get; set; }
        public int? Year { get; set; }
        public decimal? TotalYear { get; set; }

        public virtual ICollection<DayStatisticals> DayStatisticals { get; set; }
        public virtual ICollection<MonthStatisticals> MonthStatisticals { get; set; }
        public virtual ICollection<WeekStatisticals> WeekStatisticals { get; set; }
    }
}
