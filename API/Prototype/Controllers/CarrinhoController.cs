using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prototype.Application.Interfaces;
using Prototype.Domain.Commands.Input.Carrinho;
using Prototype.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICarrinhoService _service;
        public CarrinhoController(ICarrinhoService service, IUnitOfWork uow)
        {
            _service = service;
            _uow = uow;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var carrinho = _service.ObterListaNoCarrinho();

            return Ok(carrinho);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] AddNewItemCommand command)
        {
            try
            {
                var result = _service.AddItemAoCarrinho(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _service.RemoverDoCarrinho(id);

                if (result.Success) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
