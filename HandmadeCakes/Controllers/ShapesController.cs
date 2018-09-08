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
    [Route("api/Shapes")]
    //[EnableCors("MyPolicy")]
    public class ShapesController : Controller
    {
        private readonly HandmadeCakesContext _context;

        public ShapesController(HandmadeCakesContext context)
        {
            _context = context;
        }

        // GET: api/Shapes
        [HttpGet]
        public IEnumerable<Shapes> GetShapes()
        {
            return _context.Shapes;
        }
    }
}