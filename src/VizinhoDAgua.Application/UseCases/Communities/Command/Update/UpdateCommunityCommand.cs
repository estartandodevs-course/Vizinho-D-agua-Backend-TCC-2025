using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.UseCases.Communities.Command.Create;

namespace VizinhoDAgua.Application.UseCases.Communities.Command.Update
{
    public class UpdateCommunityCommand(string? title, string? description, string? coverImage) : IRequest<CommandResponse<Unit>>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; } = title;
        public string? Description { get; set; } = description;
        public string? CoverImage { get; set; } = coverImage;

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

            return validationResult.IsValid;
        }
    }
}
