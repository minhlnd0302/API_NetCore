using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.testModel
{
    public partial class Description
    {
        public long Id { get; set; }
        public string Ram { get; set; }
        public string Cpu { get; set; }
        public string Os { get; set; }
        public string ScreenSize { get; set; }
        public string Battery { get; set; }
        public string Memory { get; set; }
        public string Color { get; set; }
        public long? ProductId { get; set; }
        public string Introduction { get; set; }

        public virtual Product Product { get; set; }
    }
}
