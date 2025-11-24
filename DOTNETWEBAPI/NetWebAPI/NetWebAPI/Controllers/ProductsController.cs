using Microsoft.AspNetCore.Mvc;
using NetWebAPI.Models.Entities;
using NetWebAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataRepository<Product> dataRepository;
        public ProductsController(IDataRepository<Product> dataRepository)
        {
            this.dataRepository = dataRepository;  
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
           return  Ok(dataRepository.GetAll());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}",Name ="Get")]
        public IActionResult Get(int id)
        {
            Product product = dataRepository.Get(id);
            if(product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if(product == null)
            {
                return BadRequest("Product is Empty");
            }
            dataRepository.Add(product);
            return CreatedAtRoute(
                "Get", new Product{
                    ID = product.ID,},
                product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            Product dbproduct = dataRepository.Get(id);
            if(dbproduct == null)
            {
                return NotFound("Product not found");
            }
            if(product == null)
            {
                return BadRequest("Product is empty");
            }
            dataRepository.Update(dbproduct,product);
            return Ok(dbproduct);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product dbproduct = dataRepository.Get(id);
            if (dbproduct == null)
            {
                return NotFound("Product not found");
            }
            dataRepository.Delete(dbproduct);
            return NoContent();
        }
    }
}
