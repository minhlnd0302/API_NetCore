using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Roles
    {
        public Roles()
        {
            Admins = new HashSet<Admins>();
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Admins> Admins { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
