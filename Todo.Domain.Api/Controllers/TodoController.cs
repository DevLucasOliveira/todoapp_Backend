﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using todo.domain.Commands;
using todo.domain.Entities;
using todo.domain.Handlers;
using todo.domain.Repositories;

namespace todo.domain.api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
            [FromServices] ITodoRepository repository)
        {
            return repository.GetAll("lucasoliveira");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices]ITodoRepository repository)
        {
            return repository.GetAllDone("lucasoliveira");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone(
            [FromServices]ITodoRepository repository)
        {
            return repository.GetAllUndone("lucasoliveira");
        }

        [Route("done/today")]
        public IEnumerable<TodoItem> GetDoneForToday(
            [FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "lucasoliveira",
                DateTime.Now.Date,
                true
                );
        }

        [Route("undone/today")]
        public IEnumerable<TodoItem> GetInactiveForToday(
            [FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "lucasoliveira",
                DateTime.Now.Date,
                false
                );
        }


        [Route("done/tomorrow")]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
            [FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "lucasoliveira",
                DateTime.Now.AddDays(1),
                true
                );
        }

        [Route("done/tomorrow")]
        public IEnumerable<TodoItem> GetUndoneForTomorrow(
            [FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "lucasoliveira",
                DateTime.Now.AddDays(1),
                false
                );
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "lucasoliveira";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody]UpdateTodoCommand command,
            [FromServices]TodoHandler handler)
        {
            command.User = "lucasoliveira";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody]MarkTodoAsDoneCommand command,
            [FromServices]TodoHandler handler)
        {
            command.User = "lucasoliveira";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody]MarkTodoAsUndoneCommand command,
            [FromServices]TodoHandler handler)
        {
            command.User = "lucasoliveira";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
