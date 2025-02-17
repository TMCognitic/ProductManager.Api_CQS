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
            return Ok(_repository.Execute(new ListeProduitQuery()).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Produit? produit = _repository.Execute(new DetailProduitQuery(id));

            if (produit is null)
                return NotFound();

            return Ok(produit);
        }

        [HttpPost]
        public IActionResult Post(AjoutProduitDto dto)
        {
            if(!_repository.Execute(new AjoutProduitCommand(dto.Nom, dto.Prix)))
                return BadRequest(dto);

            return NoContent();
        }

        [HttpPut("{id}")]
        [HttpPatch("{id}")]
        public IActionResult Put(int id, ModifieProduitDto dto)
        {
            if (!_repository.Execute(new ModifierProduitCommand(id, dto.Nom, dto.Prix)))
                return BadRequest(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repository.Execute(new SupprimerProduitCommand(id)))
                return BadRequest();

            return NoContent();
        }
    }
}
