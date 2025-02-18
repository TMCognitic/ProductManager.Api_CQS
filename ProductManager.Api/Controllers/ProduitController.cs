using CommandQuerySeparation.Results;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.Domain.Commands;
using ProductManager.Api.Domain.Entities;
using ProductManager.Api.Domain.Queries;
using ProductManager.Api.Domain.Repositories;
using ProductManager.Api.Models.Dtos;

namespace ProductManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitRepository _repository;

        public ProduitController(IProduitRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Result<IEnumerable<Produit>> queryResult = _repository.Execute(new ListeProduitQuery());

            if(queryResult.IsFailure)
            {
                return BadRequest(new { queryResult.ErrorMessage });
            }

            return Ok(queryResult.Content);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Result<Produit> queryResult = _repository.Execute(new DetailProduitQuery(id));

            if (queryResult.IsFailure)
                return BadRequest(new { queryResult.ErrorMessage });

            return Ok(queryResult.Content);
        }

        [HttpPost]
        public IActionResult Post(AjoutProduitDto dto)
        {
            Result commandResult = _repository.Execute(new AjoutProduitCommand(dto.Nom, dto.Prix));

            if(commandResult.IsFailure)
                return BadRequest(new { commandResult.ErrorMessage });

            return NoContent();
        }

        [HttpPut]
        [HttpPatch]
        public IActionResult Put(ModifieProduitDto dto)
        {
            Result commandResult = _repository.Execute(new ModifierProduitCommand(dto.Id, dto.Nom, dto.Prix));

            if (commandResult.IsFailure)
                return BadRequest(new { commandResult.ErrorMessage });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result commandResult = _repository.Execute(new SupprimerProduitCommand(id));

            if (commandResult.IsFailure)
                return BadRequest(new { commandResult.ErrorMessage });

            return NoContent();
        }
    }
}
