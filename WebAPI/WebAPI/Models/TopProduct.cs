using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public partial class TopProduct
    {
        [JsonIgnore] 
        public int Id { get; set; }
        [JsonIgnore] 
        public long? ProductId { get; set; } 
        public virtual Product Product { get; set; }
    }
}
