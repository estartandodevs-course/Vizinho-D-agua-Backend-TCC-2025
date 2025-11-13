using NetTopologySuite.Geometries;

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

    public class Report : Entity
    {
        
        public string Description { get; private set; } = string.Empty;
        public ReportStatus Status { get; private set; } = ReportStatus.InProcessing;
        public ReportType ReportType { get; private set; }
        public List<string> Attachments { get; private set; } = [];

        public Guid LocationId { get; private set; }
        public Location? Location { get; private set; }

        public Guid ReporterId { get; private set; } 
        public User? Reporter { get; private set; }

        public Report() { } // EF Core

        public Report(Guid reporterId, string description, string? status, string? reportType,
            Guid locationId, List<string>? attachments = null)
        {
            ReporterId = reporterId;
            Description = description;

            if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse(status, true, out ReportStatus parsedStatus))
                Status = parsedStatus;

            if (!string.IsNullOrWhiteSpace(reportType) && Enum.TryParse(reportType, true, out ReportType parsedType))
                ReportType = parsedType;
            else
                throw new ArgumentException("Invalid Report type");

            LocationId = locationId;
            Attachments = attachments ?? [];
        }
    }
}