using Microsoft.AspNetCore.Mvc;
using RESTfulReference.Infraestrutura.Catalogo;

namespace RESTfulReference.Aplicacao.Fiscal.Controladores
{
    [ApiController]
    [Route("fiscal-documents")]
    public class FiscalDocumentController : Controller
    {

        private readonly ContextoDadosCatalogo _db;
        private readonly ILogger<FiscalDocumentController> _logger;

        public FiscalDocumentController(ContextoDadosCatalogo db)
        {
            _db = db;
        }

        //[HttpPost]
        //[Route("{id}")]
        //public IActionResult GenerateDocumentMoved(string id)
        //{
        //    Response.Headers.Append("Location", $"/fiscal-documents/");
        //    return StatusCode(301);
        //}

        //[HttpPost]
        //public IActionResult GenerateDocument([FromBody] RPS rps)
        //{

        //    try
        //    {
        //        var rpsID = new DocumentRepository(_db).GenerateDocument(rps);

        //        return Accepted($"/fiscal-documents/receipts/{rpsID}/status");
        //    }
        //    catch (ArgumentNullException argEx)
        //    {
        //        return BadRequest(argEx.Message);
        //    }
        //    catch (ConflitoEntidadeException confEx)
        //    {
        //        return Conflict(confEx.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Internal error");
        //    }
        //}

        //[HttpGet]
        //[Route("receipts/{rpsID}/status")]
        //public IActionResult GetRPSStatus(string rpsID)
        //{
        //    try
        //    {
        //        var repository = new DocumentRepository(_db);
        //        var status = repository.GetStatus(rpsID);

        //        if (status == NFSeStatus.Criada)
        //        {
        //            var rps = repository.GetRPS(rpsID);
        //            Response.Headers.Append("Location", $"/fiscal-documents/{rps.DocumentNumber}");
        //            return StatusCode(303);
        //        }

        //        return Ok(status);
        //    }
        //    catch (MalformedIdException malEx)
        //    {
        //        return BadRequest(malEx.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Internal error");
        //    }
        //}


        //[HttpGet]
        //[Route("{number}")]
        //public IActionResult GetDocument(string number)
        //{
        //    try
        //    {
        //        var repository = new DocumentRepository(_db);
        //        var document = repository.GetDocument(number);

        //        if (document == null)
        //            return NotFound();

        //        return Ok(document);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Internal error");
        //    }
        //}
    }
}
