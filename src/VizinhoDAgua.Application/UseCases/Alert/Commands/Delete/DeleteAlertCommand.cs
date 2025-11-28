using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.Delete
{
    public class DeleteAlertCommand : IRequestWithValidationAndId<Unit> // tipo void
    {
        public Guid Id { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public DeleteAlertCommand(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<DeleteAlertCommand>();

            validations.RuleFor(command => command.Id)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do usuário é obrigatório.");

            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
