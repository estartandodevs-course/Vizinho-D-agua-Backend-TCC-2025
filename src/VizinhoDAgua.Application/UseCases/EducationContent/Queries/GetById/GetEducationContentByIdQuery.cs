using System.Net;
using FluentValidation;
using FluentValidation.Results;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetById
{
    public class GetEducationContentByIdQuery 
        : IRequestWithValidationAndId<GetEducationContentByIdQueryResponse>
    {
        public Guid Id { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public GetEducationContentByIdQuery(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<GetEducationContentByIdQuery>();
            
            validations.RuleFor(command => command.Id)
                .NotEmpty() 
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do conteúdo educacional é obrigatório.");
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
