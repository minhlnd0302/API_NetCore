using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using WebAPI.Models;

namespace WebAPI.DTOModels
{
    public class ProductDTO
    { 
        public long Id { get; set; }
        public string Name { get; set; } 
        public decimal? Price { get; set; }
        public long? CategoryId { get; set; }
        public long? BrandId { get; set; }
        public long? Stock { get; set; }

        public List<string> images { get; set; } 
        public DescriptionDTO description { get; set; }
    }
}
