using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandmadeCakes.Models;
using Microsoft.AspNetCore.Cors;

namespace HandmadeCakes.Controllers
{
    [Produces("application/json")]
    [Route("api/SquareShape")]
    //[EnableCors("MyPolicy")]
    public class SquareShapeController : Controller
    {        
        private readonly HandmadeCakesContext _context;

        public SquareShapeController(HandmadeCakesContext context)
        {
            _context = context;
        }
        
        // POST: api/SquareShape
        [HttpPost]
        public async Task<IActionResult> PostSquareShape([FromBody] Order order)
        {
            decimal totalPrice = 0;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                totalPrice = CalaulatePrice(order);
                order.Price = totalPrice;
            }
            catch (DbUpdateException)
            {

            }
            return Ok(order);
        }
        
        // Calculate Price
        private decimal CalaulatePrice(Order order)
        {
            decimal finalPrice = 0;

            int sizeBasePrice = 1; // for 100 grams
            decimal textBasePrice = 1;
            // set base price
            decimal basePrice = _context.Shapes.SingleOrDefault(e => e.Id == order.ShapeId).Price;
                       
            decimal toppingsTotalPrice = 0;
            decimal sizePrice = 0;
            decimal textPrice = 0;

            // set size price
            sizePrice = Convert.ToDecimal((order.Size / 100) * sizeBasePrice);

            // set Toppings price            
            foreach (int toppingId in order.lstToppings)
            {
                toppingsTotalPrice +=
                     _context.Toppings.SingleOrDefault(e => e.Id == toppingId).Price;
            }
            
            // set text Price
            if (!string.IsNullOrWhiteSpace(order.Message))
            {
                textPrice = textBasePrice;
            }

            finalPrice = basePrice + toppingsTotalPrice + sizePrice + textPrice;

            return finalPrice;
        }
    }
}