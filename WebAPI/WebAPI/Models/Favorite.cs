using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Favorite
    {
        public long Id { get; set; }
        //public bool? IsFavorited { get; set; }
        public long? CustomerId { get; set; }
        public long? ProductId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
