using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Products
    {
        public Products()
        {
            Comments = new HashSet<Comments>();
            Descriptions = new HashSet<Descriptions>();
            Favorite = new HashSet<Favorite>();
            Images = new HashSet<Images>();
            OrderDetails = new HashSet<OrderDetails>();
            TopProducts = new HashSet<TopProducts>();
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

        public virtual Brands Brand { get; set; }
        public virtual Categories Category { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Descriptions> Descriptions { get; set; }
        public virtual ICollection<Favorite> Favorite { get; set; }
        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<TopProducts> TopProducts { get; set; }
    }
}
