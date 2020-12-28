using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Comment
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? ProductId { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
        public int? Ratting { get; set; }
        public bool? Bought { get; set; }

        [JsonIgnore] 
        public virtual Customer Customer { get; set; }
        [JsonIgnore] 
        public virtual Product Product { get; set; }
    }
}
