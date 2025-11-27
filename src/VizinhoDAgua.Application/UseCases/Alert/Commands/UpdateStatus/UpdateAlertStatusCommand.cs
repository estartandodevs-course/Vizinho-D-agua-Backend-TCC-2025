using System.Net;
using FluentValidation;
using FluentValidation.Results;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.UpdateStatus
{
    public class UpdateAlertStatusCommand : IRequestWithValidationAndId<AlertStatus>
    {
        public Guid Id { get; private set; }
        public AlertStatus Status { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public UpdateAlertStatusCommand(Guid id, AlertStatus status)
        {
            Id = id;
            Status = status;
        }

        public bool Validate()
        {
            var validator = new InlineValidator<UpdateAlertStatusCommand>();

            validator.RuleFor(command => command.Id)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O Id é obrigatório para atualização.");

            validator.RuleFor(command => command.Status)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O nome do arquivo é obrigatório para gerar o link de upload.");

            ValidationResult = validator.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}