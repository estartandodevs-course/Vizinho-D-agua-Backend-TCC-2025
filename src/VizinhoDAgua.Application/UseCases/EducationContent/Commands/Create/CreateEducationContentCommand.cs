using System.Net;
using FluentValidation;
using FluentValidation.Results;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create
{
    public class CreateEducationContentCommand : IRequestWithValidation<CreateEducationContentResponse>
    {
        public string Title { get; private set; } = string.Empty;
        public string? Image { get; private set; }
        public string Author { get; private set; }  = string.Empty;
        public EducationContentType ContentType { get; private set; }
        public string? FilePath { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public CreateEducationContentCommand() { } // permitir instâncias

        public CreateEducationContentCommand(string title, string? image, string author, 
            EducationContentType contentType, string? filePath)
        {
            Title = title;
            Image = image;
            Author = author;
            ContentType = contentType;
            FilePath = filePath;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<CreateEducationContentCommand>();
            
            validations.RuleFor(command => command.Title)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O título é obrigatório.");
            
            validations.RuleFor(command => command.Author)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O Autor é obrigatório.");
            
            validations.RuleFor(command => command.ContentType)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O tipo de arquivo deve ser informado.");
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
