using System;
using System.Collections.Generic;

namespace HandmadeCakes.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
