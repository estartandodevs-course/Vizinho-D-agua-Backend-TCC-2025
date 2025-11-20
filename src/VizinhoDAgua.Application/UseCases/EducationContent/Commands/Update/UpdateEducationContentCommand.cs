using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Update
{
    public class UpdateEducationContentCommand : IRequestWithValidationAndId<Unit>
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Image  { get; private set; }
        public string? Author { get; private set; }
        public string ContentType { get; private set; }
    
        public ValidationResult ValidationResult { get; private set; } = null!;
    
        public UpdateEducationContentCommand(Guid id, string title, string? image, string? author, string contentType)
        {
            Id = id;
            Title = title;
            Image = image;
            Author = author;
            ContentType = contentType;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UpdateEducationContentCommand>();
            
            // TODO: validações de entrada para atualizar usuários
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
