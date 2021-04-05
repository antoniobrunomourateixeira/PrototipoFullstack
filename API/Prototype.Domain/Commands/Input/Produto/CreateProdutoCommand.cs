using Flunt.Notifications;
using Flunt.Validations;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Domain.Commands.Input.Produto
{
    public class CreateProdutoCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Tem_Promocao { get; set; }
        public Guid? Id_Promocao { get; set; }

        public CreateProdutoCommand()
        {
            this.Tem_Promocao = false;
            this.Id_Promocao = null;
        }

        public bool Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMaxLen(Nome, 100, "Nome", "O nome não pode ter mais de 100 caracteres")
            .HasMinLen(Nome, 3, "Nome", "O nome não pode ter menos de 3 caracteres")
            .IsNotNullOrEmpty(Nome, "Nome", "O nome não pode ser nulo")
            );
            return Valid;
        }
    }
}
