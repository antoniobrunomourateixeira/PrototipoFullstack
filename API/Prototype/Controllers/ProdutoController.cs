using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Prototype.Application.Interfaces;
using Prototype.Domain.Commands.Input.Produto;
using Prototype.Domain.Entities;
using Prototype.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var promocao = _uow.GetRepository<Promocao>().Get();
            var produto = _uow.GetRepository<Produto>().Get().Include(p => promocao);

            var produtoWhere = new List<Produto>();
            foreach (var item in produto)
            {
                if (item.Tem_Promocao)
                {
                    var data = promocao.Where(p => p.Id == item.Id_Promocao.GetValueOrDefault());
                    item.Promocao = (Promocao)data.FirstOrDefault();
                }

                produtoWhere.Add(item);
            }

            return Ok(produtoWhere);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            var promocaoUnica = _service.ObterProdutoPorId(Id);

            return Ok(promocaoUnica);
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

        [HttpPut]
        [AllowAnonymous]
        public IActionResult Update([FromBody] UpdateProdutoCommand command)
        {

            try
            {
                var result = _service.UpdateProduto(command);
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
                var result = _service.DeleteProduto(id);

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
