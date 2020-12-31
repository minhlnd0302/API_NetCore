using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Orders>();
        }

        public long Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
