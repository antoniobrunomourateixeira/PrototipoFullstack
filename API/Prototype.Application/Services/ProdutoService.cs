using Prototype.Application.Interfaces;
using Prototype.Domain.Commands.Input.Produto;
using Prototype.Domain.Commands.Output;
using Prototype.Domain.Entities;
using Prototype.Domain.Handlers;
using Prototype.Domain.Interfaces.IUnitOfWork;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoHandler _handler;
        private readonly IUnitOfWork _uow;

        public ProdutoService(ProdutoHandler handler, IUnitOfWork uow)
        {
            _handler = handler;
            _uow = uow;
        }

        public ICommandResult CreateProduto(CreateProdutoCommand command)
        {
            command.Validate();
            if (!command.Valid)
                return new CommandResult(success: false, message: null, data: command.Notifications);

            if(command.Tem_Promocao && command.Id_Promocao == null)
                return new CommandResult(success: false, message: "ID da Promoção vazia", data: null);

            return _handler.Handle(command);
        }

        public IQueryable<Produto> ObterListDeProdutos()
        {
            try
            {
                var promocoes = _uow.GetRepository<Produto>().Get(predicate: x => x.Active == true);

                return promocoes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IQueryable<Produto> ObterProdutoPorId(Guid produtoId)
        {
            try
            {
                var promocao = _uow.GetRepository<Produto>().Get(
                 predicate: x => x.Id == produtoId &&
                 x.Active == true);

                return promocao;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
