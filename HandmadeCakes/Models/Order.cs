using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandmadeCakes.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderToppings = new HashSet<OrderToppings>();
        }

        public long Id { get; set; }
        public long? UserId { get; set; }
        public int ShapeId { get; set; }
        public int Size { get; set; }
        public string Toppings { get; set; }
        public string Message { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public Shapes Shape { get; set; }
        public User User { get; set; }
        public ICollection<OrderToppings> OrderToppings { get; set; }

        [NotMapped]
        public List<int> lstToppings { get; set; }
    }
}
