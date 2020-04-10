using Covid19.Application.Common.Mappings;
using Covid19.Domain.Entities;

namespace Covid19.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
