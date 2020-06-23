using todo.domain.Entities;

namespace todo.domain.Repositories
{
    interface ITodoRepository
    {
        void Create(TodoItem todo);
        void Update(TodoItem todo);
    }
}
