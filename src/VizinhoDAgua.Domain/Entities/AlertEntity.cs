using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Domain.Entities
{
    public class AlertEntity : Entity
    {
        public string Description { get; private set; } = string.Empty;
        public AlertStatus Status { get; private set; }

        public string PostalCode { get; private set; } = string.Empty;
        public string? City { get; private set; }
        public string? StateCode { get; private set; }

        public List<ReportEntity> Reports { get; private set; } = [];

        public AlertEntity() { }

        public AlertEntity(string description, string postalCode, string? city, string? stateCode)
        {
            Description = description;
            PostalCode = postalCode;
            City = city;
            StateCode = stateCode;
            Status = AlertStatus.UnderVerification;
        }

        public void UpdateStatus(AlertStatus newStatus)
        {
            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AttachReport(ReportEntity report)
        {
            Reports.Add(report);
        }
    }
}