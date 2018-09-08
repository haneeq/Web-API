using System;
using System.Collections.Generic;

namespace HandmadeCakes.Models
{
    public partial class OrderToppings
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public int ToppingsId { get; set; }

        public Order Order { get; set; }
        public Toppings Toppings { get; set; }
    }
}
