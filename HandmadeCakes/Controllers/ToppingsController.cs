using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandmadeCakes.Models;

namespace HandmadeCakes.Controllers
{
    [Produces("application/json")]
    [Route("api/Toppings")]
    public class ToppingsController : Controller
    {
        private readonly HandmadeCakesContext _context;

        public ToppingsController(HandmadeCakesContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public IEnumerable<Toppings> GetToppings()
        {
            return _context.Toppings;
        }
        
    }
}