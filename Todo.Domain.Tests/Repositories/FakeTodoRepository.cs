using System;
using System.Collections.Generic;
using todo.domain.Entities;
using todo.domain.Repositories;

namespace todo.domain.tests.Repositories
{
    class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {

        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Titulo novo", "Lucas Oliveira", DateTime.Now);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todo)
        {

        }
    }
}
