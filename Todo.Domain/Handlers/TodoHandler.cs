using Flunt.Notifications;
using todo.domain.Commands;
using todo.domain.Commands.Contracts;
using todo.domain.Entities;
using todo.domain.Handlers.Contracts;
using todo.domain.Repositories;

namespace todo.domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndoneCommand>
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
                return new GenericCommandResult(false, "Ocorreu um erro com sua tarefa", command.Notifications);

            // Gerar o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            // Salvar no banco
            _repository.Create(todo);

            // Retornar o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro ao alterar a tarefa", command.Notifications);

            // Recupera o TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o título
            todo.UpdateTitle(command.Title);

            // Salva no banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro ao marcar a tarefa como concluida", command.Notifications);

            // Recupera o TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o estado
            todo.MarkAsDone();

            // Salva no banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);

        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro ao marcar a tarefa como nao concluida", command.Notifications);

            // Recupera o TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o estado
            todo.MarkAUndone();

            // Salva no banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}
