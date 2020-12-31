using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public partial class WeekStatistical
    {
        public WeekStatistical()
        {
            DayStatisticals = new HashSet<DayStatistical>();
        }

        [JsonIgnore]
        public long Id { get; set; }
        public int? Week { get; set; }
        [JsonIgnore]
        public long? MonthId { get; set; }
        [JsonIgnore]
        public long? YearId { get; set; }
        public decimal? TotalWeek { get; set; }
        [JsonIgnore]
        public virtual MonthStatistical Month { get; set; }
        [JsonIgnore]
        public virtual YearStatistical Year { get; set; }
        [JsonIgnore]
        public virtual ICollection<DayStatistical> DayStatisticals { get; set; }
    }
}
