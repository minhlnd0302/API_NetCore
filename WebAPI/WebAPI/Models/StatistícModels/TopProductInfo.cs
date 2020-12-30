using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.StatistícModels
{
    public class TopProductInfo
    {
        public string Name { get; set; }
        public long BuyingTime { get; set; }
        public int Rate { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
