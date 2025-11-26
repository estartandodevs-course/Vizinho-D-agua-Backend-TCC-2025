using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Community.Commands.Unfollow
{
    public class UnfollowCommunityCommand : IRequestWithValidation<Unit>
    {
        public Guid CommunityId { get; private set; }
        public Guid UserId { get; private set; }
        public ValidationResult ValidationResult { get; private set; } = null!;

        public UnfollowCommunityCommand(Guid communityId, Guid userId)
        {
            CommunityId = communityId;
            UserId = userId;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UnfollowCommunityCommand>();

            validations.RuleFor(c => c.UserId)
                .NotEmpty()
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("O ID do usuário é obrigatório.");

            validations.RuleFor(c => c.CommunityId)
                .NotEmpty()
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("O ID da comunidade é obrigatório.");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
