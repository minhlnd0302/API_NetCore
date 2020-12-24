using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.testModel
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
