using Prototype.Domain.Commands.Input.Promocao;
using Prototype.Domain.Entities;
using Prototype.Domain.Interfaces.IUnitOfWork.Collections;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype.Application.Interfaces
{
   public interface IPromocaoService
   {
        ICommandResult CreatePromocao(CreatePromocaoCommand command);

        IQueryable<Promocao> ObterPromocaoPorId(Guid promocaoId);
        IQueryable<Promocao> ObterListDePromocoes();
   }
}
