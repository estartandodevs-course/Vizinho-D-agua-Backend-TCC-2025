using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Domain.Entities
{
    public class EducationContentEntity : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public UserEntity? Author { get; private set; }
        public Guid? AuthorId { get; private set; }
        public EducationContentType ContentType { get; private set; }
        public string? FilePath { get; private set; } = string.Empty;

        public EducationContentEntity() { } // EF Core

        public EducationContentEntity(string title, Guid authorId, 
            EducationContentType contentType, string? filePath)
        {
            Title = title;
            AuthorId = authorId;
            ContentType = contentType;
            FilePath = filePath;
        }
    }
}
