using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Contacts
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Email { get; set; }
        public bool? IsReply { get; set; }
        public string Message { get; set; }
        public string Phone { get; set; }
    }
}
