using System;
using System.Collections.Generic;

namespace HandmadeCakes.Models
{
    public partial class Toppings
    {
        public Toppings()
        {
            OrderToppings = new HashSet<OrderToppings>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderToppings> OrderToppings { get; set; }
    }
}
