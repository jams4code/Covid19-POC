﻿using Covid19.Application.TodoLists.Commands.UpdateTodoList;
using Covid19.Application.UnitTests.Common;
using Covid19.Domain.Entities;
using Shouldly;
using Xunit;

namespace Covid19.Application.UnitTests.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenListTitleIsUnique()
        {
            var command = new UpdateTodoListCommand
            {
                Id = 1,
                Title = "Shopping"
            };

            var validator = new UpdateTodoListCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenListTitleIsNotUnique()
        {
            Context.TodoLists.Add(new TodoList { Title = "Shopping" });
            Context.SaveChanges();

            var command = new UpdateTodoListCommand
            {
                Id = 2,
                Title = "Shopping"
            };

            var validator = new UpdateTodoListCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
