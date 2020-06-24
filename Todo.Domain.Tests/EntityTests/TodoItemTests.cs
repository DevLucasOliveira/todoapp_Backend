using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using todo.domain.Entities;

namespace todo.domain.tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Lavar o aquario", "Lucas Oliveira", DateTime.Now);

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}
