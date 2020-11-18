using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class UseVoucher
    {
        public long Id { get; set; }
        public bool? Used { get; set; }
        public long? CustomerId { get; set; }
        public long? VoucherId { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
