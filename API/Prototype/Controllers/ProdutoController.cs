using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prototype.Application.Interfaces;
using Prototype.Domain.Commands.Input.Produto;
using Prototype.Domain.Entities;
using Prototype.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service, IUnitOfWork uow)
        {
            _service = service;
            _uow = uow;
        }

        
        [HttpGet()]
        public IActionResult GetAll()
        {
            var promocao = _uow.GetRepository<Produto>().Get();

            return Ok(promocao);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] CreateProdutoCommand command)
        {
            try
            {
                var result = _service.CreateProduto(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
