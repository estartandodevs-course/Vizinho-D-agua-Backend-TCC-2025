using VizinhoDAgua.Domain.Entities.Abstractions;

namespace VizinhoDAgua.Domain.Entities
{
    public enum ReportType
    {
        WaterOutage,
        LowPressure,
        LeakDetected
    }

    public enum ReportStatus
    {
        Archived,
        InProcessing,
        Processed,
        Discarded
    }

    public class ReportEntity : Entity
    {
        
        public string Description { get; private set; } = string.Empty;
        public ReportStatus Status { get; private set; } = ReportStatus.InProcessing;
        public ReportType ReportType { get; private set; }
        public List<string> Attachments { get; private set; } = [];

        public Guid LocationId { get; private set; }
        public LocationEntity? Location { get; private set; }

        public Guid? ReporterId { get; private set; } 
        public UserEntity? Reporter { get; private set; }

        public ReportEntity() { } // EF Core

        public ReportEntity(Guid reporterId, string description, string? status, string? reportType,
            Guid locationId, List<string>? attachments = null)
        {
            ReporterId = reporterId;
            Description = description;

            if (!string.IsNullOrWhiteSpace(status) && System.Enum.TryParse(status, true, out ReportStatus parsedStatus))
                Status = parsedStatus;

            if (!string.IsNullOrWhiteSpace(reportType) && System.Enum.TryParse(reportType, true, out ReportType parsedType))
                ReportType = parsedType;
            else
                throw new ArgumentException("Invalid Report type");

            LocationId = locationId;
            Attachments = attachments ?? [];
        }
    }
}