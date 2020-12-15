
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;
using System.Linq;

namespace testeef.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {

         
        
        

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {

           
          
           // Inclui1produtoTeste(context);

            var products = await context.Products.Include(x => x.Category) .ToListAsync();
            //var products = await context.Products.ToListAsync();
            return products;
        } 





        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetbyId([FromServices] DataContext context, int id)
        {



            var products = await context.Products.Include(x => x.Category) 
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return products;
        } 

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetbyCategory([FromServices] DataContext context, int id)
        {

           

            var products = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .Where (x => x.Categoryid == id)
            .ToListAsync();

            return products;
        }                 


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody] Product model
            )
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }  


    }
}