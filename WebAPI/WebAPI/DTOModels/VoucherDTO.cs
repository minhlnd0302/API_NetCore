using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOModels
{
    public class VoucherDTO
    {
        public long Id { get; set; }
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string Code { get; set; }
        public int? DiscountPercent { get; set; }
        public string Name { get; set; }
    }
}
