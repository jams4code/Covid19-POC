using Covid19.Application.Common.Exceptions;
using Covid19.Application.TodoLists.Commands.UpdateTodoList;
using Covid19.Application.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Covid19.Application.UnitTests.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedTodoList()
        {
            var command = new UpdateTodoListCommand
            {
                Id = 1,
                Title = "Shopping",
            };

            var handler = new UpdateTodoListCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.TodoLists.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.Title.ShouldBe(command.Title);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateTodoListCommand
            {
                Id = 99,
                Title = "Bucket List",
            };

            var handler = new UpdateTodoListCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
