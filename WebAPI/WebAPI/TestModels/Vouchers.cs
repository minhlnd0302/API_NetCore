using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Vouchers
    {
        public Vouchers()
        {
            UseVoucher = new HashSet<UseVoucher>();
        }

        public long Id { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string Code { get; set; }
        public int? DiscountPercent { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UseVoucher> UseVoucher { get; set; }
    }
}
