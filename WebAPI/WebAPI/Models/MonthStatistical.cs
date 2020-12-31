using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public partial class MonthStatistical
    {
        public MonthStatistical()
        {
            DayStatisticals = new HashSet<DayStatistical>();
            WeekStatisticals = new HashSet<WeekStatistical>();
        }

        [JsonIgnore]
        public long Id { get; set; }
        public int? Month { get; set; }
        [JsonIgnore]
        public long? YearId { get; set; }
        public decimal? TotalMonth { get; set; }

        [JsonIgnore]
        public virtual YearStatistical Year { get; set; }
        [JsonIgnore]
        public virtual ICollection<DayStatistical> DayStatisticals { get; set; }
        [JsonIgnore]
        public virtual ICollection<WeekStatistical> WeekStatisticals { get; set; }
    }
}
