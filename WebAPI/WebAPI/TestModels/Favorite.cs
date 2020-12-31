using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Favorite
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? ProductId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Products Product { get; set; }
    }
}
