using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore] 
        public virtual ICollection<Circle> Circle { get; set; } 

        [JsonIgnore] 
        public virtual ICollection<Product> Products { get; set; }
    }
}
