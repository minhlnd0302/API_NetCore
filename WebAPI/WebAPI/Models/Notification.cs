using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Notification
    {
        public long Id { get; set; }
        public bool Seen { get; set; }
        public int Type { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
    }
}
