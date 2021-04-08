using Flunt.Notifications;
using Flunt.Validations;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Domain.Commands.Input.Carrinho
{
    public class UpdateItemCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
            .Requires());
            return Valid;
        }
    }
}