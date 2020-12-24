using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.testModel
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetail>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
