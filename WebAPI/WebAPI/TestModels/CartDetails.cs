using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class CartDetails
    {
        public long Id { get; set; }
        public long? CartId { get; set; }
        public long? Quantity { get; set; }
        public long? Price { get; set; }

        public virtual Carts Cart { get; set; }
    }
}
