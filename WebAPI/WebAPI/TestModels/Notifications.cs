using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Notifications
    {
        public long Id { get; set; }
        public bool? Seen { get; set; }
        public int? Type { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
    }
}
