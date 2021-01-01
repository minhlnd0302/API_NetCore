using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public partial class TopCustomer
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? LastBuy { get; set; }

        public int TotalOrders { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
