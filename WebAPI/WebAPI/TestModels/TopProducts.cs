using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class TopProducts
    {
        public int Id { get; set; }
        public long? ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
