using FluentValidation;
using FluentValidation.Results;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Queries.GetById
{
    public class GetCommunityPostByIdQuery : IRequestWithValidationAndId<GetCommunityPostByIdQueryResponse>
    {
        public Guid Id { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public GetCommunityPostByIdQuery(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<GetCommunityPostByIdQuery>();

            validations.RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O ID da comunidade é obrigatório");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
