using Flunt.Notifications;
using todo.domain.Commands;
using todo.domain.Commands.Contracts;
using todo.domain.Entities;
using todo.domain.Handlers.Contracts;
using todo.domain.Repositories;

namespace todo.domain.Handlers
{
    class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ocorreu um erro com sua tarefa",
                    command.Notifications);

            // Gerar o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            // Salvar no banco
            _repository.Create(todo);

            // Retornar o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}
