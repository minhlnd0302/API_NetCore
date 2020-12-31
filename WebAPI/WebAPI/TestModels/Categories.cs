using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Categories
    {
        public Categories()
        {
            Circle = new HashSet<Circle>();
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Circle> Circle { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
