using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOModels
{
    public class OrderDetailDTO
    {
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
