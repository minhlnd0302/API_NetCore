using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Carts
    {
        public Carts()
        {
            CartDetails = new HashSet<CartDetails>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<CartDetails> CartDetails { get; set; }
    }
}
