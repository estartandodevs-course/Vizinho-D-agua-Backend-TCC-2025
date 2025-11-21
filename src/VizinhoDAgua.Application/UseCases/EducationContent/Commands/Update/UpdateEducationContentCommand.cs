using System.Net;
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
        public string Author { get; private set; }
        public string? FilePath { get; private set; }
    
        public ValidationResult ValidationResult { get; private set; } = null!;
    
        public UpdateEducationContentCommand(Guid id, string title, string? image, string author, string? filePath)
        {
            Id = id;
            Title = title;
            Image = image;
            Author = author;
            FilePath = filePath;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UpdateEducationContentCommand>();
            
            validations.RuleFor(command => command.Id)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do conteúdo educacional é obrigatório para a atualização.");
            
            validations.RuleFor(command => command)
                .Must(command => !(string.IsNullOrEmpty(command.Title) && string.IsNullOrEmpty(command.Image) 
                                                                       && string.IsNullOrEmpty(command.Author)
                                                                       && string.IsNullOrEmpty(command.FilePath)
                    )
                )
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("Pelo menos um campo deve ser fornecido para a atualização.");
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
