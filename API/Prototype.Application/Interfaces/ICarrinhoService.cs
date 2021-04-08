using Prototype.Domain.Commands.Input.Carrinho;
using Prototype.Domain.Entities;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype.Application.Interfaces
{
    public interface ICarrinhoService
    {
        ICommandResult AddItemAoCarrinho(AddNewItemCommand command);
        ICommandResult UpdateItemCarrinho(UpdateItemCommand command);
        List<Carrinho> ObterListaNoCarrinho();
        ICommandResult RemoverDoCarrinho(Guid id);
    }
}
