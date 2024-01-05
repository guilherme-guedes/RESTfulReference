using Microsoft.AspNetCore.Mvc;
using RestfulReference.Infrastructure;
using RESTfulReference.Exceptions;
using RESTfulReference.Domain.Entities.Taxes;
using RESTfulReference.Infrastructure.Repositories;

namespace RESTfulReference.Application.Controllers
{
    [ApiController]
    [Route("fiscal-documents")]
    public class FiscalDocumentController : Controller
    {

        private readonly DatabaseContext _db;
        private readonly ILogger<FiscalDocumentController> _logger;

        public FiscalDocumentController(DatabaseContext db)
        {
            this._db = db;
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GenerateDocumentMoved(string id)
        {
            Response.Headers.Append("Location", $"/fiscal-documents/");
            return StatusCode(301);
        }

        [HttpPost]
        public IActionResult GenerateDocument([FromBody] RPS rps)
        {

            try
            {
                var rpsID = new DocumentRepository(this._db).GenerateDocument(rps);

                return Accepted($"/fiscal-documents/receipts/{rpsID}/status");
            }
            catch (ArgumentNullException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (EntityConflictedException confEx)
            {
                return Conflict(confEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }

        [HttpGet]
        [Route("receipts/{rpsID}/status")]
        public IActionResult GetRPSStatus(string rpsID)
        {
            try
            {
                var repository = new DocumentRepository(this._db);
                var status = repository.GetStatus(rpsID);

                if (status == Domain.Entities.Taxes.Enums.NFSeStatus.Created)
                {
                    var rps = repository.GetRPS(rpsID); 
                    Response.Headers.Append("Location", $"/fiscal-documents/{rps.DocumentNumber}");
                    return StatusCode(303);
                }
                
                return Ok(status);
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


        [HttpGet]
        [Route("{number}")]
        public IActionResult GetDocument(string number)
        {
            try
            {
                var repository = new DocumentRepository(this._db);
                var document = repository.GetDocument(number);

                if (document == null)
                    return NotFound();

                return Ok(document);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }
    }
}
