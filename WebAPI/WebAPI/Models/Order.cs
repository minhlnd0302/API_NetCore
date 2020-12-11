using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public long? CustomerId { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public string ShippingAddress { get; set; }
        public long? StatusId { get; set; }
        public string Note { get; set; }
        public string PaymentMethod { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
