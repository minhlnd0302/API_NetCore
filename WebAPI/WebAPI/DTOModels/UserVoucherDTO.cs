using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOModels
{
    public class UserVoucherDTO
    {  
        public long? CustomerId { get; set; } 
        public string Date { get; set; } 
        public string CodeVoucher { get; set; }
         
    }
}
