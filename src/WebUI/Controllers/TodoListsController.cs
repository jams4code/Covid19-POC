﻿using Covid19.Application.TodoLists.Commands.CreateTodoList;
using Covid19.Application.TodoLists.Commands.DeleteTodoList;
using Covid19.Application.TodoLists.Commands.UpdateTodoList;
using Covid19.Application.TodoLists.Queries.ExportTodos;
using Covid19.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Covid19.WebUI.Controllers
{
    [Authorize]
    public class TodoListsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<TodosVm>> Get()
        {
            return await Mediator.Send(new GetTodosQuery());
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            ExportTodosVm vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateTodoListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}
