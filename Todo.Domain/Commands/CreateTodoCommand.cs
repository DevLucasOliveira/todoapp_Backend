﻿using Flunt.Notifications;
using Flunt.Validations;
using System;
using todo.domain.Commands.Contracts;

namespace todo.domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Por favor, descreve melhor esta tarefa!")
                .HasMinLen(User, 6, "User", "Usuário inválido!")
                );
        }
    }
}
