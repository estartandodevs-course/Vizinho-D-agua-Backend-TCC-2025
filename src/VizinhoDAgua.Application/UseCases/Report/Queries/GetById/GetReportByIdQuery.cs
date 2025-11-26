using System.Net;
using FluentValidation;
using FluentValidation.Results;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Report.Queries.GetById
{
    public class GetReportByIdQuery: IRequestWithValidationAndId<GetReportByIdQueryResponse>
    {
        public Guid Id { get; private set; }
    
        public ValidationResult ValidationResult { get; private set; } = null!;
    
        public GetReportByIdQuery(Guid id)
        {
            Id = id;
        }
    
        public bool Validate()
        {
            var validations = new InlineValidator<GetReportByIdQuery>();
                
            validations.RuleFor(command => command.Id)
                .NotEmpty() 
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do report é obrigatório.");
                
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
