using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class CartDetail
    {
        public long Id { get; set; }
        public long? CartId { get; set; }
        public long? Quantity { get; set; }
        public long? Price { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
