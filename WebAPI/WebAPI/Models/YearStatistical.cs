using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public partial class YearStatistical
    {
        public YearStatistical()
        {
            DayStatisticals = new HashSet<DayStatistical>();
            MonthStatisticals = new HashSet<MonthStatistical>();
            WeekStatisticals = new HashSet<WeekStatistical>();
        }
        [JsonIgnore]
        public long Id { get; set; }
        public int? Year { get; set; }
        public decimal? TotalYear { get; set; }

        public virtual ICollection<DayStatistical> DayStatisticals { get; set; }
        public virtual ICollection<MonthStatistical> MonthStatisticals { get; set; }
        public virtual ICollection<WeekStatistical> WeekStatisticals { get; set; }
    }
}
