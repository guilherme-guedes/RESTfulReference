using Microsoft.AspNetCore.Mvc;
using RESTfulReference.Aplicacao.Catalogo.Servicos;
using RESTfulReference.Dominio.Catalog;
using RESTfulReference.Dominio.Catalogo.Entidades;
using RESTfulReference.Exceptions;
using RESTfulReference.Infraestrutura.Catalogo;
using RESTfulReference.Infraestrutura.Catalogo.Repositorios;

namespace RESTfulReference.Aplicacao.Catalogo.Controllers
{

    [ApiController]
    [Route("catalogo")]
    public class ControllerCatalogo : Controller
    {
        private readonly RepositorioServico repositorioServico;
        private readonly RepositorioProduto repositorioProduto;
        private readonly ILogger<ControllerCatalogo> _logger;

        public ControllerCatalogo(RepositorioServico repositorioServico, RepositorioProduto repositorioProduto)
        {
            this.repositorioServico = repositorioServico;
            this.repositorioProduto = repositorioProduto;
        }

        [HttpPost]
        [Route("produtos")]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {

            try
            {
                var produtoRetornado = this.repositorioProduto.Adicionar(produto);
                return Created($"{produtoRetornado.Id}", produtoRetornado);
            }
            catch (ArgumentNullException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (ConflitoEntidadeException confEx)
            {
                return Conflict(confEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }

        [HttpPost]
        [Route("servicos")]
        public IActionResult AdicionarServico([FromBody] Servico servico)
        {
            try
            {
                var servicoRetornado = this.repositorioServico.Adicionar(servico);
                return Created($"{servicoRetornado.Id}", servicoRetornado);
            }
            catch (ArgumentNullException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (ConflitoEntidadeException confEx)
            {
                return Conflict(confEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }


        //[HttpPut]
        //public IActionResult UpdateProduct([FromBody] Produto product)
        //{

        //    try
        //    {
        //        var catalog = new ServicoAplicacaoCatalogo(repository);

        //        catalog.CheckIntegrity(product);

        //        if (!catalog.CheckIfModified(product))
        //            return StatusCode(304);

        //        return Ok(repository.Update(product));
        //    }
        //    catch (EntitdadeNaoEncontradaException enfEx)
        //    {
        //        return NotFound(enfEx.Message);
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


        //[HttpDelete]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        new RepositorioServico(_db).Delete(id);
        //        return NoContent();
        //    }
        //    catch (EntitdadeNaoEncontradaException enfEx)
        //    {
        //        return NotFound(enfEx.Message);
        //    }
        //    catch (ArgumentNullException argEx)
        //    {
        //        return BadRequest(argEx.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Internal error");
        //    }
        //}


        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult Get(string id)
        //{
        //    try
        //    {
        //        var product = new RepositorioServico(_db).GetById(id);

        //        if (product == null)
        //            return NotFound();

        //        return Ok(product);
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
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        var product = new RepositorioServico(_db).GetAll();

        //        if (product == null)
        //            return NoContent();

        //        return Ok(product);
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
    }
}
