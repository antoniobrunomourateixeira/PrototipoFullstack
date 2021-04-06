using Prototype.Application.Interfaces;
using Prototype.Domain.Commands.Input.Promocao;
using Prototype.Domain.Commands.Output;
using Prototype.Domain.Entities;
using Prototype.Domain.Handlers;
using Prototype.Domain.Interfaces.IUnitOfWork;
using Prototype.Shared.Commands;
using System;
using System.Linq;

namespace Prototype.Application.Services
{
    public class PromocaoService : IPromocaoService
    {
        private readonly PromocaoHandler _handler;
        private readonly IUnitOfWork _uow;

        public PromocaoService(PromocaoHandler handler, IUnitOfWork uow)
        {
            _handler = handler;
            _uow = uow;
        }

        public ICommandResult CreatePromocao(CreatePromocaoCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return new CommandResult(success: false, message: null, data: command.Notifications);

            return _handler.Handle(command);

        }

        public ICommandResult UpdatePromocao(UpdatePromocaoCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return new CommandResult(success: false, message: null, data: command.Notifications);

            return _handler.Handle(command);

        }

        public IQueryable<Promocao> ObterListDePromocoes()
        {
            try
            {
                var promocoes = _uow.GetRepository<Promocao>().Get(predicate: x => x.Active == true);

                return promocoes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICommandResult DeletePromocao(Guid id)
        {
            return _handler.Handle(id);
        }

        public IQueryable<Promocao> ObterPromocaoPorId(Guid promocaoId)
        {
            //var promocao = _uow.GetRepository<Promocao>().GetFirstOrDefault(predicate: x => x.Active == true, x.Id == promocaoId);

            var promocao = _uow.GetRepository<Promocao>().Get(
                  predicate: x => x.Id == promocaoId &&
                  x.Active == true);

            return promocao;
        }
    }
}
