using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Communities.Command.Create
{
    public class CreateCommunityCommand(string title, string description, string? coverImage) : IRequest<CommandResponse<CreateCommunityCommandResponse>>
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public string? CoverImage { get; private set; } = coverImage;

        public ValidationResult validationResult { get; private set; }

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

            validationResult = validations.Validate(this);

            return validationResult.IsValid;
        }
    }
}
