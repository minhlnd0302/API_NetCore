using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class UseVoucher
    {
        public long ID { get; set; }
        public bool? Used { get; set; }
        public long? CustomerId { get; set; }
        public long? VoucherId { get; set; }

        public virtual Vouchers Voucher { get; set; }
    }
}
