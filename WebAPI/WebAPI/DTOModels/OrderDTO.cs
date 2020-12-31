using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOModels
{
    public class OrderDTO
    {
        public DateTime? Date { get; set; }
        public long CustomerId { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string ShippingAddress { get; set; }
        public long StatusId { get; set; }
        public string Note { get; set; } 
        public string PaymentMethod { get; set; }
        public virtual List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
