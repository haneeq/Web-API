using System;
using System.Collections.Generic;

namespace HandmadeCakes.Models
{
    public partial class Shapes
    {
        public Shapes()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
