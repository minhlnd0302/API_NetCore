using Newtonsoft.Json;
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
        [JsonIgnore]
        public long? CustomerId { get; set; }
        [JsonIgnore]
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        [JsonIgnore]
        public string ShippingAddress { get; set; }
        [JsonIgnore]
        public long? StatusId { get; set; }
        [JsonIgnore]
        public string Note { get; set; }

        [JsonIgnore]
        public string PaymentMethod { get; set; }

        [JsonIgnore] 
        public virtual Customer Customer { get; set; }
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
