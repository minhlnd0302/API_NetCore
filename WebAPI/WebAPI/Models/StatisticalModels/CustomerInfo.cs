using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.StatistícModels
{
    public class CustomerInfo
    {
        public string Name { get; set; }
        public int BuyingTime { get; set; }
        public int LastBuy { get; set; }
    }
}
