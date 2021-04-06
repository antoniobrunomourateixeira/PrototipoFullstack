using Flunt.Notifications;
using Flunt.Validations;
using Prototype.Shared.Commands;
using System;

namespace Prototype.Domain.Commands.Input.Promocao
{
    public class UpdatePromocaoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int Leve { get; set; }
        public int Pague { get; set; }
        public decimal Valor { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMaxLen(Descricao, 80, "Descricao", "O nome não pode ter mais de 80 caracteres")
            .HasMinLen(Descricao, 5, "descricao", "O nome não pode ter menos de 5 caracteres")
            .IsNotNullOrEmpty(Descricao, "Descricao", "O nome não pode ser nulo"));
            return Valid;
        }
    }
}
