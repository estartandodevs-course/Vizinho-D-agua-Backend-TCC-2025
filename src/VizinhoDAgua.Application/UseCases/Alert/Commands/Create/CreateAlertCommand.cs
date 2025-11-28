using System.Net;
using FluentValidation;
using FluentValidation.Results;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.Create
{
    public class CreateAlertCommand : IRequestWithValidation<CreateAlertCommandResponse>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string PostalCode { get; private set; }

        // Campos preenchidos automaticamente pelo ViaCEP
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }
        public string? City { get; private set; }
        public string? StateCode { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public CreateAlertCommand(string title, string description, string postalCode)
        {
            Title = title;
            Description = description;
            PostalCode = postalCode;
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
            var validator = new InlineValidator<CreateAlertCommand>();

            validator.RuleFor(command => command.Title)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O título é obrigatório.");

            validator.RuleFor(command => command.Description)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("A descrição é obrigatória.");

            validator.RuleFor(command => command.PostalCode)
                .NotEmpty()
                .Length(8)
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O CEP é obrigatório.");

            ValidationResult = validator.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
