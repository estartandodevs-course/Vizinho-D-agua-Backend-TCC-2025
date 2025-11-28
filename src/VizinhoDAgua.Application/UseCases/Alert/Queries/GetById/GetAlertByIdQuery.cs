using System.Net;
using FluentValidation;
using FluentValidation.Results;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Alert.Queries.GetById;

public class GetAlertByIdQuery : IRequestWithValidationAndId<GetAlertByIdQueryResponse>
{
    public Guid Id { get; private set; }
    
    public ValidationResult ValidationResult { get; private set; } = null!;
    
    public  GetAlertByIdQuery(Guid id)
    {
        Id = id;
    }

    public bool Validate()
    {
        var validations = new InlineValidator<GetAlertByIdQuery>();
        
        validations.RuleFor(command => command.Id)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O ID do alerta é obrigatório.");
        
        ValidationResult = validations.Validate(this);
        return ValidationResult.IsValid;
    }
}