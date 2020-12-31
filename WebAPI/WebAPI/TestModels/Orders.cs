using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
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

        public virtual Customers Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
