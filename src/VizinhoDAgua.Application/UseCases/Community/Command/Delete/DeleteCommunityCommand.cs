using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Community.Command.Delete
{
    public class DeleteCommunityCommand : IRequest<CommandResponse<Unit>>
    {
        public Guid Id { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public DeleteCommunityCommand(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<DeleteCommunityCommand>();

            validations.RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O ID da comunidade é obrigatório para a deleção.");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
