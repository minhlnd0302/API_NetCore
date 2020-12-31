using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class OrderDetails
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? CurrentPrice { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
