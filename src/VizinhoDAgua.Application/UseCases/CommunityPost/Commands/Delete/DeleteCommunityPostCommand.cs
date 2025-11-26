using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Command.Delete
{
    public class DeleteCommunityPostCommand : IRequestWithValidationAndId<Unit>
    {
        public Guid Id { get; private set; }
        public ValidationResult ValidationResult { get; private set; } = null!;

        public DeleteCommunityPostCommand(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<DeleteCommunityPostCommand>();

            validations.RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O ID da comunidade é obrigatório para a deleção.");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
