using System;
using todo.domain.Entities;
using todo.domain.Repositories;

namespace todo.domain.tests.Repositories
{
    class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {

        }
        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Titulo novo", "Lucas Oliveira", DateTime.Now);
        }

        public void Update(TodoItem todo)
        {

        }
    }
}
