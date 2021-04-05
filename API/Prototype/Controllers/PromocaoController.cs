using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prototype.Application.Interfaces;
using Prototype.Domain.Commands.Input.Promocao;
using Prototype.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IPromocaoService _service;
        public PromocaoController(IPromocaoService service, IUnitOfWork uow)
        {
            _service = service;
            _uow = uow;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var promocao = _service.ObterListDePromocoes();

            return Ok(promocao);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid promocaoId)
        {
            var promocaoUnica = _service.ObterPromocaoPorId(promocaoId);

            return Ok(promocaoUnica);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] CreatePromocaoCommand command)
        {

            try
            {
                var result = _service.CreatePromocao(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
