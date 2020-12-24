using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.testModel
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Comments = new HashSet<Comment>();
            Favorites = new HashSet<Favorite>();
            Orders = new HashSet<Order>();
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

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
