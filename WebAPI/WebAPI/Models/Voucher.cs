﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            UseVouchers = new HashSet<UseVoucher>();
        }

        public long Id { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string Code { get; set; }

        public virtual ICollection<UseVoucher> UseVouchers { get; set; }
    }
}
