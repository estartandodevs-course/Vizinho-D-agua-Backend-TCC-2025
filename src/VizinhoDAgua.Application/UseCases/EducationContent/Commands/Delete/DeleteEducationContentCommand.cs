using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Delete
{
    public class DeleteEducationContentCommand : IRequestWithValidationAndId<Unit>
    {
        public Guid Id { get; private set; }
    
        public ValidationResult ValidationResult { get; private set; } = null!;
    
        public DeleteEducationContentCommand(Guid id)
        {
            Id = id;
        }
    
        public bool Validate()
        {
            var validations = new InlineValidator<DeleteEducationContentCommand>();
            
            // TODO: validações de entrada para deletar usuários
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
