using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public partial class DayStatistical
    {
        [JsonIgnore]
        public long Id { get; set; }
        public int? Day { get; set; }
        [JsonIgnore]
        public long? WeekId { get; set; }
        [JsonIgnore]
        public long? MonthId { get; set; }
        [JsonIgnore]
        public long? YearId { get; set; }
        public decimal? TotalDay { get; set; }

        [JsonIgnore]
        public virtual MonthStatistical Month { get; set; }
        [JsonIgnore]
        public virtual WeekStatistical Week { get; set; }
        [JsonIgnore]
        public virtual YearStatistical Year { get; set; }
    }
}
