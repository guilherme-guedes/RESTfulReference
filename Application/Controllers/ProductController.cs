using Microsoft.AspNetCore.Mvc;
using RestfulReference.Domain.Entities;
using RestfulReference.Infrastructure;
using RestfulReference.Infrastructure.Repositories;
using RESTfulReference.Services;
using RESTfulReference.Exceptions;

namespace RestfulReference.Application.Controllers
{

    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly ILogger<ProductController> _logger;

        public ProductController(DatabaseContext db)
        {
            this._db = db;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {

            try
            {
                var repository = new ProductRepository(this._db);
                
                new Catalog(repository).CheckIntegrity(product);

                repository.Create(product);

                return Accepted();
            }
            catch (ArgumentNullException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (ConflictedProductException confEx)
            {
                return Conflict(confEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }


        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {

            try
            {
                var repository = new ProductRepository(this._db);
                var catalog = new Catalog(repository);
                
                catalog.CheckIntegrity(product);

                if (!catalog.CheckIfModified(product))
                    return StatusCode(304);

                repository.Update(product);

                return NoContent();
            }
            catch (EntityNotFoundException enfEx)
            {
                return NotFound(enfEx.Message);
            }
            catch (ArgumentNullException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (ConflictedProductException confEx)
            {
                return Conflict(confEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            try
            {
                new ProductRepository(this._db).Delete(id);
                return NoContent();
            }
            catch (EntityNotFoundException enfEx)
            {
                return NotFound(enfEx.Message);
            }
            catch (ArgumentNullException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }


        [HttpGet]
        public IActionResult Get(string id)
        {
            try
            {
                var product = new ProductRepository(this._db).GetById(id);

                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (MalformedIdException malEx)
            {
                return BadRequest(malEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }
    }
}
