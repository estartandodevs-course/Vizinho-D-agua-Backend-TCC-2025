using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Communities.Command.Create
{
    public class CreateCommunityCommand : IRequest<CommandResponse<CreateCommunityCommandResponse>>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string? CoverImage { get; private set; }

        public ValidationResult ValidationResult { get; private set; }

        public CreateCommunityCommand(string title, string description, string? coverImage)
        {
            Title = title;
            Description = description;
            CoverImage = coverImage;
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

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
