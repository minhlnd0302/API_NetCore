using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Image
    {
        [JsonIgnore] 
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public string Url { get; set; }

        [JsonIgnore] 
        public virtual Product Product { get; set; }
    }
}
