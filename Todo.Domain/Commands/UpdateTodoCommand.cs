using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using todo.domain.Commands.Contracts;

namespace todo.domain.Commands
{
    class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand() { }
        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor")
                .HasMinLen(User, 6, "User", "Uusário inválido"));
        }
    }
}
