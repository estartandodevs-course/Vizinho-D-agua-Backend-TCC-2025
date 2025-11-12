using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Communities.Command.Update
{
    public class UpdateCommunityCommand : IRequest<CommandResponse<Unit>>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }

        public ValidationResult validationResult { get; private set; }

        public UpdateCommunityCommand(Guid id, string? title, string? description, string? coverImage)
        {
            Id = id;
            Title = title;
            Description = description;
            CoverImage = coverImage;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UpdateCommunityCommand>();

            validations.RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("O ID da comunidade é obrigatório para a atualização.");

            validations.RuleFor(c => c)
            .Must(c => !(string.IsNullOrEmpty(c.Title) && string.IsNullOrEmpty(c.Description) && string.IsNullOrEmpty(c.CoverImage)))
            .WithMessage("Pelo menos um campo (Título, Descrição ou Imagem) deve ser fornecido para a atualização.");

            validationResult = validations.Validate(this);

            return validationResult.IsValid;
        }
    }
}
