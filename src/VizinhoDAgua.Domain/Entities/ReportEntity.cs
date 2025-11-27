using NetTopologySuite.Geometries;
using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Domain.Entities
{
    public class ReportEntity : Entity
    {
        public string Description { get; private set; } = string.Empty;
        public ReportStatus Status { get; private set; } = ReportStatus.InProcessing;
        public ReportType ReportType { get; private set; }
        public WaterCompany WaterCompanyRelated { get; private set; }
        public List<string> Attachments { get; private set; } = [];

        public Guid ReporterId { get; private set; } 
        public UserEntity Reporter { get; private set; }
        
        public Guid? AlertId { get; private set; }
        public AlertEntity? Alert { get; private set; }

        // Endereço
        public string? City { get; private set; } = string.Empty;
        public string? StateCode { get; private set; } = string.Empty;
        public string PostalCode { get; private set; } = string.Empty;
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }
        public Geometry? Geometry { get; private set; }

        public ReportEntity() { } // EF Core

        public ReportEntity(
            Guid reporterId, 
            string description,
            WaterCompany waterCompanyRelated,
            string postalCode,
            string city,
            string stateCode,
            string? road,
            string? neighborhood,
            ReportStatus status,
            ReportType reportType,
            List<string>? attachments = null)
        {
            ReporterId = reporterId;
            Description = description;
            Attachments = attachments ?? [];
            WaterCompanyRelated = waterCompanyRelated;
            Status = status;
            ReportType = reportType;

            // Endereço
            City = city;
            StateCode = stateCode;
            PostalCode = postalCode;
            Road = road;
            Neighborhood = neighborhood;
        }
        
        public void UpdateAddressFromCep(
            string? road,
            string? neighborhood,
            string? city,
            string? stateCode,
            string? postalCode)
        {
            if (!string.IsNullOrWhiteSpace(city))
                City = city;

            if (!string.IsNullOrWhiteSpace(stateCode))
                StateCode = stateCode;

            if (!string.IsNullOrWhiteSpace(postalCode))
                PostalCode = postalCode;

            if (!string.IsNullOrWhiteSpace(road))
                Road = road;

            if (!string.IsNullOrWhiteSpace(neighborhood))
                Neighborhood = neighborhood;
        }
    }
}
