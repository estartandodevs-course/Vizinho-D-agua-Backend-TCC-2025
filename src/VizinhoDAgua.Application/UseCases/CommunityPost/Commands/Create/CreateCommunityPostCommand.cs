using FluentValidation;
using FluentValidation.Results;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Commands.Create
{
    public class CreateCommunityPostCommand : IRequestWithValidation<CreateCommunityPostCommandResponse>
    {
        public Guid AuthorId { get; private set; }
        public Guid CommunityId { get; private set; }
        public string Content { get; private set; }
        public List<string> Images { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public CreateCommunityPostCommand(Guid authorId, Guid communityId, string content, List<string> images)
        {
            AuthorId = authorId;
            CommunityId = communityId;
            Content = content;
            Images = images ?? [];
        }

        public bool Validate()
        {
            var validations = new InlineValidator<CreateCommunityPostCommand>();

            validations.RuleFor(c => c.AuthorId)
               .NotEmpty()
               .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
               .WithMessage("O id do autor é obrigatório.");

            validations.RuleFor(c => c.CommunityId)
               .NotEmpty()
               .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
               .WithMessage("O id da comunidade é obrigatório.");

            validations.RuleFor(c => c.Content)
               .NotEmpty()
               .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
               .WithMessage("O conteúdo é obrigatório.");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
