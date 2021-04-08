using Prototype.Domain.Commands.Input.Produto;
using Prototype.Domain.Entities;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype.Application.Interfaces
{
    public interface IProdutoService
    {
        ICommandResult CreateProduto(CreateProdutoCommand command);
        ICommandResult UpdateProduto(UpdateProdutoCommand command);
        ICommandResult DeleteProduto(Guid id);
        Produto ObterProdutoPorId(Guid produtoId);
        IQueryable<Produto> ObterListDeProdutos();
    }
}
