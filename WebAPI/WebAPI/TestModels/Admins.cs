using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Admins
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }

        public virtual Roles RoleNavigation { get; set; }
    }
}
