using System;
using System.Collections.Generic;

namespace WebAPI.TestModels
{
    public partial class Customers
    {
        public Customers()
        {
            Carts = new HashSet<Carts>();
            Comments = new HashSet<Comments>();
            Favorite = new HashSet<Favorite>();
            Orders = new HashSet<Orders>();
            TopCustomers = new HashSet<TopCustomers>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool? Verified { get; set; }

        public virtual Roles RoleNavigation { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Favorite> Favorite { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<TopCustomers> TopCustomers { get; set; }
    }
}
