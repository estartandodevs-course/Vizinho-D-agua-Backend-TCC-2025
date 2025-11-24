using NetTopologySuite.Geometries;
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

        public Guid? ReporterId { get; private set; } 
        public UserEntity? Reporter { get; private set; }

        // Endereço
        public string? City { get; private set; } = string.Empty;
        public string? StateCode { get; private set; } = string.Empty;
        public string? PostalCode { get; private set; }
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }
        public Geometry? Geometry { get; private set; }

        public ReportEntity() { } // EF Core

        public ReportEntity(
            Guid reporterId, 
            string description,
            string postalCode,
            string city,
            string stateCode,
            string? road,
            string? neighborhood,
            string? status, 
            string? reportType,
            List<string>? attachments = null)
        {
            ReporterId = reporterId;
            Description = description;
            Attachments = attachments ?? [];

            if (!string.IsNullOrWhiteSpace(status) && System.Enum.TryParse(status, true, out ReportStatus parsedStatus))
                Status = parsedStatus;

            if (!string.IsNullOrWhiteSpace(reportType) && System.Enum.TryParse(reportType, true, out ReportType parsedType))
                ReportType = parsedType;
            else
                throw new ArgumentException("Tipo de denúncia não é valido");

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("CEP não é válido");

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Cidade não é valido");

            if (string.IsNullOrWhiteSpace(stateCode))
                throw new ArgumentException("Código do estado não é válido");

            // Endereço
            City = city;
            StateCode = stateCode;
            PostalCode = postalCode;
            Road = road;
            Neighborhood = neighborhood;
        }


    }
}