using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail
{
    public class CommonProperties
    {
        public DateTime Created { get; set; } = new DateTime(1900, 1, 1);
        public DateTime Update { get; set; } = new DateTime(1900, 1, 1);
        public string Message { get; set; }
    }
}
