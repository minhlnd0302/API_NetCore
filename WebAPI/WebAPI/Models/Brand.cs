using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        [JsonIgnore] 
        public virtual ICollection<Product> Products { get; set; }
    }
}
