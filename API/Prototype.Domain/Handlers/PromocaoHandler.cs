using Flunt.Notifications;
using Prototype.Domain.Commands.Input.Promocao;
using Prototype.Domain.Commands.Output;
using Prototype.Domain.Entities;
using Prototype.Domain.Interfaces.IUnitOfWork;
using Prototype.Shared.Commands;
using System;

namespace Prototype.Domain.Handlers
{
    public class PromocaoHandler : Notifiable,
        ICommandHandler<CreatePromocaoCommand>
    {
        private readonly IUnitOfWork _uow;

        public PromocaoHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ICommandResult Handle(CreatePromocaoCommand command)
        {
            try
            {
                var promocao = new Promocao (command.Descricao, command.Leve, command.Pague, command.Valor);

                _uow.GetRepository<Promocao>()
                    .Save(promocao);
                _uow.SaveChanges();

                return new CommandResult(success: true, message: "Promoção salvo com sucesso", data: promocao.Id);
            }
            catch (Exception ex)
            {
                return new CommandResult(success: false, message: ex.Message, data: null);

            }
        }

        public ICommandResult Handle(UpdatePromocaoCommand command)
        {
            try
            {
                var promocao = _uow
                    .GetRepository<Promocao>()
                    .GetFirstOrDefault(predicate: x => x.Id == command.Id);

                if (promocao != null)
                {
                    promocao.UpdatePromocao(command.Descricao, command.Leve, command.Pague, command.Valor);
                    _uow.GetRepository<Promocao>().Update(entity: promocao);
                    _uow.SaveChanges();
                    return new CommandResult(success: true, message: "Promoção alterada com sucesso", data: command);
                }

                return new CommandResult(success: false, message: "Promoção não encontrada", data: command);

            }
            catch (Exception ex)
            {
                return new CommandResult(success: false, message: ex.Message, data: null);
            }
        }

        public ICommandResult Handle(Guid id)
        {
            try
            {
                var promocao = _uow.GetRepository<Promocao>().GetFirstOrDefault(predicate: x => x.Id == id);

                promocao.Disable();

                _uow.GetRepository<Promocao>().Delete(id);

                _uow.SaveChanges();

                return new CommandResult(success: true, message: "Promoção removida com sucesso", data: null);
            }
            catch (Exception ex)
            {
                return new CommandResult(success: false, message: ex.Message, data: null);
            }
        }
    }
}
