using Flunt.Notifications;
using Prototype.Domain.Commands.Input.Produto;
using Prototype.Domain.Commands.Output;
using Prototype.Domain.Entities;
using Prototype.Domain.Interfaces.IUnitOfWork;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Domain.Handlers
{
    public class ProdutoHandler : Notifiable,
        ICommandHandler<CreateProdutoCommand>
    {
        private readonly IUnitOfWork _uow;
        public ProdutoHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ICommandResult Handle(CreateProdutoCommand command)
        {
            try
            {
                var produto = new Produto(command.Nome, command.Valor, command.Tem_Promocao, command.Id_Promocao);

                _uow.GetRepository<Produto>()
                    .Save(produto);
                _uow.SaveChanges();

                return new CommandResult(success: true, message: "produto salvo com sucesso", data: produto.Id);
            }
            catch (Exception ex)
            {
                return new CommandResult(success: false, message: ex.Message, data: null);

            }
        }
    }
}
