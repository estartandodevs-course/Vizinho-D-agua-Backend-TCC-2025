using FluentValidation;
using FluentValidation.Results;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Community.Commands.Create
{
    public class CreateCommunityCommand : IRequestWithValidation<CreateCommunityCommandResponse>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string? CoverImage { get; private set; }
        public Guid CreatedById { get; set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public CreateCommunityCommand(string title, string description, string? coverImage, Guid createdById)
        {
            Title = title;
            Description = description;
            CoverImage = coverImage;
            CreatedById = createdById;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<CreateCommunityCommand>();

            validations.RuleFor(c => c.Title)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O título é obrigatório.");

            validations.RuleFor(c => c.Description)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("A descrição é obrigatória.");

            validations.RuleFor(c => c.CreatedById)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do usuário criador é obrigatório.");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
