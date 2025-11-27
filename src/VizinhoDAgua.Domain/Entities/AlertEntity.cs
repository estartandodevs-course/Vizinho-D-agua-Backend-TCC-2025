using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Domain.Entities
{
    public class AlertEntity : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public AlertStatus Status { get; private set; }
        public string PostalCode { get; private set; } = string.Empty;
        public string? City { get; private set; }
        public string? StateCode { get; private set; }
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }

        public List<ReportEntity> Reports { get; private set; } = [];

        public AlertEntity() { }

        public AlertEntity(string title, string description, string postalCode, string? city, string? stateCode, string? road, string? neighborhood)
        {
            Title = title;
            Description = description;
            PostalCode = postalCode;
            City = city;
            StateCode = stateCode;
            Status = AlertStatus.UnderVerification;
            Road = road;
            Neighborhood = neighborhood;
        }
    }
}