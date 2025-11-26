using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.UpdateStatus
{
    public class UpdateAlertStatusCommand : IRequestWithValidationAndId<Unit>
    {
        public Guid Id { get; private set; }
        public AlertStatus NewStatus { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public UpdateAlertStatusCommand(Guid id, AlertStatus newStatus)
        {
            Id = id;
            NewStatus = newStatus;
        }

        public bool Validate()
        {
            var validator = new InlineValidator<UpdateAlertStatusCommand>();

            validator.RuleFor(command => command.Id)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O Id é obrigatório para atualização.");
            
            ValidationResult = validator.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}