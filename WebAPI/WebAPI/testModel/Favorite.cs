using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.testModel
{
    public partial class Favorite
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? ProductId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
