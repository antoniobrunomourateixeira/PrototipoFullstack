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
        public IActionResult GetById(Guid Id)
        {
            var promocaoUnica = _service.ObterPromocaoPorId(Id);

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

        [HttpPut]
        [AllowAnonymous]
        public IActionResult Update([FromBody] UpdatePromocaoCommand command)
        {

            try
            {
                var result = _service.UpdatePromocao(command);
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
                var result = _service.DeletePromocao(id);

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
