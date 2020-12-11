﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Image
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public string Url { get; set; }

        public virtual Product Product { get; set; }
    }
}
