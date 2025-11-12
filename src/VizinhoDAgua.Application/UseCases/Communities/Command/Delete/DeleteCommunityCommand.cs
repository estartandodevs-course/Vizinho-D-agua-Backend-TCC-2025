using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Communities.Command.Delete
{
    public class DeleteCommunityCommand : IRequest<CommandResponse<Unit>>
    {
        public Guid Id { get; private set; }
        public ValidationResult validationResult { get; private set; }

        public DeleteCommunityCommand(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<DeleteCommunityCommand>();

            validations.RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("O ID da comunidade é obrigatório para a atualização.");

            validationResult = validations.Validate(this);

            return validationResult.IsValid;
        }
    }
}
