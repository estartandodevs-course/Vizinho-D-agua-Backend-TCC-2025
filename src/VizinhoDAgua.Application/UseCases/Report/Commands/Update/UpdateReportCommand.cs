using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Update
{
    public class UpdateReportCommand : IRequestWithValidationAndId<Unit>
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public string ReportType { get; private set; }
        public string ReporterId { get; private set; }

        // Endereço
        public string PostalCode { get; private set; }
        public string? City { get; private set; }
        public string? StateCode { get; private set; }
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }
        public double? Lat { get; private set; }
        public double? Lon { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;
        
        public UpdateReportCommand(Guid id, string description, string reportType, string reporterId, string postalCode,
            string? stateCode, string? city, string? neighborhood, string? road, double? lat, double? lon
        )
        {
            Id = id;
            Description = description;
            ReportType = reportType;
            ReporterId = reporterId;
            PostalCode = postalCode;
            City = city;
            StateCode = stateCode;
            Road = road;
            Neighborhood = neighborhood;
            Lat = lat;
            Lon = lon;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UpdateReportCommand>();

            validations.RuleFor(command => command.Id)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do report é obrigatório para a atualização.");
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
