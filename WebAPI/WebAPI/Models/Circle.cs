using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public partial class Circle
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int? SoldQuantity { get; set; }
        public long? CategoryId { get; set; } 
        public virtual Category Category { get; set; }
    }
}
