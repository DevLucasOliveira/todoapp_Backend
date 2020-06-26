using System;
using System.Collections.Generic;
using todo.domain.Entities;

namespace todo.domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todo);
        void Update(TodoItem todo);
        TodoItem GetById(Guid id, string user);
        IEnumerable<TodoItem> GetAll(string user);
        IEnumerable<TodoItem> GetAllDone(string user);
        IEnumerable<TodoItem> GetAllUndone(string user);
        IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
    }
}
