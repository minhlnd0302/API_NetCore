using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Admin
    {
        public long Id { get; set; }
        public string UserName { get; set; } 

        [JsonIgnore]
        public string Password { get; set; }
        public int? Role { get; set; } 

        [JsonIgnore]
        public virtual Role RoleNavigation { get; set; }
    }
}
