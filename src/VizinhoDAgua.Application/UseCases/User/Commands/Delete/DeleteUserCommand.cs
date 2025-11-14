using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Delete
{
    // DTO de entrada para deletar o usuário
    public class DeleteUserCommand : IRequest<CommandResponse<Unit>> // tipo void
    {
        public Guid Id { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<DeleteUserCommand>();
            
            // TODO: validações de entrada para deletar usuários

            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
