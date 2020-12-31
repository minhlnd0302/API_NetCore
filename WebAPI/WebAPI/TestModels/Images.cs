using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Images
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public string Url { get; set; }

        public virtual Products Product { get; set; }
    }
}
