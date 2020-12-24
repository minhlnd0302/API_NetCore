using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.testModel
{
    public partial class UseVoucher
    {
        public long ID { get; set; }
        public bool? Used { get; set; }
        public long? CustomerId { get; set; }
        public long? VoucherId { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
