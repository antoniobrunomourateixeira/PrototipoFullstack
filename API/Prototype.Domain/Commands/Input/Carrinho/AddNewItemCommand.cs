using Flunt.Notifications;
using Flunt.Validations;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Domain.Commands.Input.Carrinho
{
    public class AddNewItemCommand: Notifiable, ICommand
    {
        public int Quantidade { get; set; }
        public Guid Id_Produto { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
            .Requires());
            return Valid;
        }
    }
}
