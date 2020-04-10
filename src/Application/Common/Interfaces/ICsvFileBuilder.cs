using Covid19.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Covid19.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
