using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Brands
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
