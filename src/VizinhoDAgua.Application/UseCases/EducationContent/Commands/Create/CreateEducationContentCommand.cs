using FluentValidation;
using FluentValidation.Results;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create
{
    public class CreateEducationContentCommand : IRequestWithValidation<CreateEducationContentResponse>
    {
        public string Title { get; private set; }
        public string? Image { get; private set; }
        public string? Author { get; private set; }
        public string ContentType { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public CreateEducationContentCommand(string title, string? image, string? author, string contentType)
        {
            Title = title;
            Image = image;
            Author = author;
            ContentType = contentType;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<CreateEducationContentCommand>();
            
            // TODO: validações de entrada para criar conteúdos educacionais
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
