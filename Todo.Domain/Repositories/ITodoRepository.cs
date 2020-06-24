using System;
using todo.domain.Entities;

namespace todo.domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todo);
        void Update(TodoItem todo);
        TodoItem GetById(Guid id, string user);
    }
}
