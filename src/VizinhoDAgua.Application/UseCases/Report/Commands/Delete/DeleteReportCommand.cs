using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Delete
{
    public class DeleteReportCommand : IRequestWithValidationAndId<Unit> // tipo void
    {
        public Guid Id { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public DeleteReportCommand(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<DeleteReportCommand>();

            validations.RuleFor(command => command.Id)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do usuário é obrigatório para a excluí-lo.");

            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
    