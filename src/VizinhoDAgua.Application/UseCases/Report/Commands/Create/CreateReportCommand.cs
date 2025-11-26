using FluentValidation;
using FluentValidation.Results;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Create
{
    public class CreateReportCommand : IRequestWithValidation<CreateReportCommandResponse>
    {
        public string Description { get; private set; } = string.Empty;
        public string ReportType { get; private set; } = string.Empty;
        public string ReporterId { get; private set; } = string.Empty;
        public string? WaterCompanyRelated { get; private set; } 

        // Endereço
        public string PostalCode { get; private set; } = string.Empty;
        public string? City { get; private set; }
        public string? StateCode { get; private set; }
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }
        public double? Lat { get; private set; }
        public double? Lon { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public CreateReportCommand() { }
        
        public CreateReportCommand(
            string description, string reportType, string waterCompanyRelated, string reporterId, string postalCode, string? stateCode,
            string? city, string? neighborhood, string? road, double? lat, double? lon)
        {
            Description = description;
            ReportType = reportType;
            ReporterId = reporterId;
            PostalCode = postalCode;
            WaterCompanyRelated = waterCompanyRelated;
            City = city;
            StateCode = stateCode;
            Road = road;
            Neighborhood = neighborhood;
            Lat = lat;
            Lon = lon;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<CreateReportCommand>();

            // Description
            validations.RuleFor(r => r.Description)
                .NotEmpty()
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("A descrição é obrigatório.");

            // ReportType
            validations.RuleFor(r => r.ReportType)
                .NotEmpty()
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("O tipo da denúncia é obrigatório.")
                .Must(value => Enum.TryParse(typeof(ReportType), value, true, out _))
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("Tipo de denúncia inválido.");

            // ReportType
            validations.RuleFor(r => r.WaterCompanyRelated)
                .NotEmpty()
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("A Compania de água é obrigatório.")
                .Must(value => Enum.TryParse(typeof(WaterCompany), value, true, out _))
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("Compania de água desconhecido.");

            // ReporterId
            validations.RuleFor(r => r.ReporterId)
                .NotEmpty()
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("O ID do denunciante é obrigatório.")
                .Must(value => Guid.TryParse(value, out _))
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("O ID do denunciante é inválido.");

            // PostalCode
            validations.RuleFor(r => r.PostalCode)
                .NotEmpty()
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("O CEP é obrigatório.")
                .Length(8)
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("CEP deve possuir ao menos 8 caracteres.");

            // StateCode (opcional)
            validations.RuleFor(r => r.StateCode)
                .Length(2)
                    .When(c => !string.IsNullOrWhiteSpace(c.StateCode))
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("UF deve conter exatamente 2 caracteres.");
            
            // City (opcional)
            validations.RuleFor(r => r.City)
                .MaximumLength(60)
                    .When(c => !string.IsNullOrWhiteSpace(c.City))
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                    .WithMessage("Valor muito grande");

            // Neighborhood (opcional)
            validations.RuleFor(r => r.Neighborhood)
                .MaximumLength(60)
                    .When(c => !string.IsNullOrWhiteSpace(c.Neighborhood))
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString());

            // Road (opcional)
            validations.RuleFor(r => r.Road)
                .MaximumLength(100)
                    .When(c => !string.IsNullOrWhiteSpace(c.Road))
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString());

            // Latitude (opcional)
            validations.RuleFor(r => r.Lat)
                .NotNull()
                    .When(c => c.Lon != null)
                    .WithMessage("Latitude é obrigatória quando longitude é informada.")
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .Must(lat => lat >= -90 && lat <= 90)
                    .When(c => c.Lat != null)
                    .WithMessage("Latitude deve estar entre -90 e 90.")
                    .WithErrorCode((HttpStatusCode.BadRequest).ToString());

            // Longitude (opcional)
            validations.RuleFor(r => r.Lon)
                .NotNull()
                    .When(c => c.Lat != null)
                    .WithMessage("Longitude é obrigatória quando latitude é informada.")
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .Must(lon => lon >= -180 && lon <= 180)
                    .When(c => c.Lon != null)
                    .WithMessage("Longitude deve estar entre -180 e 180.")
                    .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString());

            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
