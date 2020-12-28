using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            Descriptions = new HashSet<Description>();
            Favorites = new HashSet<Favorite>();
            Images = new HashSet<Image>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public long? BuyingTimes { get; set; }
        public string DateArrive { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public double? Rating { get; set; }
        public long? CategoryId { get; set; }
        public long? BrandId { get; set; }
        public long? Stock { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; }

        [JsonIgnore] 
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        [JsonIgnore] 
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
