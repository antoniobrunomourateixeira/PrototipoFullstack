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
using AutoMapper.QueryableExtensions;
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

            var produto = _uow.GetRepository<Carrinho>().GetFirstOrDefault(
                 predicate: x => x.Id_Produto == command.Id_Produto &&
                 x.Active == true);

            if(produto != null)
            {
                var updateCarrinho = new UpdateItemCommand();
                updateCarrinho.Id = produto.Id;
                updateCarrinho.Quantidade = produto.Quantidade + command.Quantidade;
                return this.UpdateItemCarrinho(updateCarrinho);
            }


            return _handler.Handle(command);
        }

        public List<Carrinho> ObterListaNoCarrinho()
        {
            try
            {
                var produto = _uow.GetRepository<Produto>().Get().OrderBy(x => x.Nome);
                var itensCarrinho = _uow.GetRepository<Carrinho>().Get(predicate: x => x.Active == true);

                var itensCarrinhoWhere = new List<Carrinho>();
                foreach (var item in itensCarrinho)
                {
                        var data = produto.Where(p => p.Id == item.Id_Produto);
                        item.Produto = (Produto)data.FirstOrDefault();


                    itensCarrinhoWhere.Add(item);
                }

                return itensCarrinhoWhere;

                //return (IQueryable<Carrinho>)itensCarrinhoWhere;
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

        public ICommandResult UpdateItemCarrinho(UpdateItemCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return new CommandResult(success: false, message: null, data: command.Notifications);

            return _handler.Handle(command);
        }
    }
}
