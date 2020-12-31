using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Circle
    {
        public int Id { get; set; }
        public int? SoldQuantity { get; set; }
        public long? CategoryId { get; set; }

        public virtual Categories Category { get; set; }
    }
}
