using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class TopCustomers
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? LastBuy { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
