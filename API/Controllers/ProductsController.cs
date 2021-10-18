using System.Collections.Generic; //for List
using System.Linq; //for ToList
using System.Threading.Tasks; //for Task
using Core.Entities;//for Product
using Infrastructure.Data;//for StoreContext
// using API.Data; //for StoreContext
// using API.Entities; //for Product
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; //for ToListAsync

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
         private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task< ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
}
}