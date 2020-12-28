using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Value { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
