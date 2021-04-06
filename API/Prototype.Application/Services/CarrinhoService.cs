using Prototype.Application.Interfaces;
using Prototype.Domain.Commands.Input.Carrinho;
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
    public class CarrinhoService : ICarrinhoService
    {
        private readonly CarrinhoHandler _handler;
        private readonly IUnitOfWork _uow;

        public CarrinhoService(CarrinhoHandler handler, IUnitOfWork uow)
        {
            _handler = handler;
            _uow = uow;
        }

        public ICommandResult AddItemAoCarrinho(AddNewItemCommand command)
        {
            #region VALIDAÇÕES
            if (command.Quantidade <= 0)
                command.AddNotification("Quantidade", "Quantidade tem que ser maior que 0");

            command.Validate();
            if (!command.Valid)
                return new CommandResult(success: false, message: null, data: command.Notifications);
            #endregion


            return _handler.Handle(command);
        }

        public IQueryable<Carrinho> ObterListaNoCarrinho()
        {
            try
            {
                var promocoes = _uow.GetRepository<Carrinho>().Get(predicate: x => x.Active == true);

                return promocoes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICommandResult RemoverDoCarrinho(Guid id)
        {
            return _handler.Handle(id);
        }
    }
}
