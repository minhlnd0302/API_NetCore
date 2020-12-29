using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOModels
{
    public class ChangePasswordDTO
    {
        public long CustomerId { get; set; }
        public string NewPassword { get; set; }
    }
}
