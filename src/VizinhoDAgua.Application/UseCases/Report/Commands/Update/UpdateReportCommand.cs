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
        public string? Description { get; private set; }
        public string? ReportType { get; private set; }
        public string? WaterCompanyRelated { get; private set; }

        // Endereço
        public string? PostalCode { get; private set; }
        public string? City { get; private set; }
        public string? StateCode { get; private set; }
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }
        public double? Lat { get; private set; }
        public double? Lon { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;
        
        public UpdateReportCommand(Guid id, string? description, string? reportType, string? waterCompanyRelated, string? postalCode,
            string? stateCode, string? city, string? neighborhood, string? road, double? lat, double? lon
        )
        {
            Id = id;
            Description = description;
            ReportType = reportType;
            WaterCompanyRelated = waterCompanyRelated;
            PostalCode = postalCode;
            City = city;
            StateCode = stateCode;
            Road = road;
            Neighborhood = neighborhood;
            Lat = lat;
            Lon = lon;
        }

        public void AddPostalCodeInRequest(string postalCode)
        {
            PostalCode = postalCode;
        }

        public void AddAddressInRequest(string city, string stateCode, string? road, string? neighborhood)
        {
            City = city;
            StateCode = stateCode;
            Road = road;
            Neighborhood = neighborhood;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UpdateReportCommand>();

            validations.RuleFor(command => command.Id)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do report é obrigatório para a atualização.");

            validations.RuleFor(c => c)
            .Must(c => !
                (
                    string.IsNullOrEmpty(c.Description) && 
                    string.IsNullOrEmpty(c.ReportType) && 
                    string.IsNullOrEmpty(c.PostalCode) &&
                    string.IsNullOrEmpty(c.WaterCompanyRelated) &&
                    string.IsNullOrEmpty(c.City) &&
                    string.IsNullOrEmpty(c.StateCode) &&
                    string.IsNullOrEmpty(c.Road) &&
                    string.IsNullOrEmpty(c.Neighborhood)
                )
            )
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("Pelo menos um campo deve ser fornecido para a atualização.");

            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
