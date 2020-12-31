using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class MonthStatisticals
    {
        public MonthStatisticals()
        {
            DayStatisticals = new HashSet<DayStatisticals>();
            WeekStatisticals = new HashSet<WeekStatisticals>();
        }

        public long Id { get; set; }
        public int? Month { get; set; }
        public long? YearId { get; set; }
        public decimal? TotalMonth { get; set; }

        public virtual YearStatisticals Year { get; set; }
        public virtual ICollection<DayStatisticals> DayStatisticals { get; set; }
        public virtual ICollection<WeekStatisticals> WeekStatisticals { get; set; }
    }
}
