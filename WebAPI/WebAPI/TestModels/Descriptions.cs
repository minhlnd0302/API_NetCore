using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Descriptions
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

        public virtual Products Product { get; set; }
    }
}
