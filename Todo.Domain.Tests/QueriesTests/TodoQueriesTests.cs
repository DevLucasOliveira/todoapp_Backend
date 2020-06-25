using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using todo.domain.Entities;
using todo.domain.Queries;

namespace todo.domain.tests.QueriesTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "lucas", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "usuarioD", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "lucas", DateTime.Now));

        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_lucas()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("lucas"));
            Assert.AreEqual(2, result.Count());
        }

    }
}
