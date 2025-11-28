using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.Update
{
    public class UpdateAlertCommand : IRequestWithValidationAndId<Unit>
    {
        public Guid Id { get; private set; }
        public AlertStatus? Status { get; private set; }

        public string? Title { get; private set; }
        public string? Description { get; private set; }

        // Localidade
        public string? PostalCode { get; private set; }
        public string? City { get; private set; }
        public string? StateCode { get; private set; }
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public UpdateAlertCommand(Guid id, AlertStatus? status, string? title, string? description,
            string? postalCode, string? city, string? stateCode, string? road, string? neighborhood)
        {
            Id = id;
            Status = status;
            Title = title;
            Description = description;
            PostalCode = postalCode;
            City = city;
            StateCode = stateCode;
            Road = road;
            Neighborhood = neighborhood;
        }
        
        // Método para atualizar os campos de endereço
        public void SetAddress(string? road, string? neighborhood, string? city, string? stateCode)
        {
            Road = road;
            Neighborhood = neighborhood;
            City = city;
            StateCode = stateCode;
        }
        
        public bool Validate()
        {
            var validations = new InlineValidator<UpdateAlertCommand>();

            validations.RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("O Id é obrigatório.");

            // pelo menos um campo para atualizar
            validations.RuleFor(command => command)
                .Must(command =>
                    command.Title != null ||
                    command.Description != null ||
                    command.PostalCode != null ||
                    command.City != null ||
                    command.StateCode != null ||
                    command.Road != null ||
                    command.Neighborhood != null ||
                    command.Status != null)
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("Pelo menos um campo deve ser informado para atualização.");
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
