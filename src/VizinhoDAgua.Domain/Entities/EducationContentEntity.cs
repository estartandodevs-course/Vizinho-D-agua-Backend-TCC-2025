using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Domain.Entities
{
    public class EducationContentEntity : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public EducationContentType ContentType { get; private set; }
        public string? FilePath { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;

        public EducationContentEntity() { } // EF Core

        public EducationContentEntity(string title, string author, 
            EducationContentType contentType, string? filePath)
        {
            Title = title;
            Author = author;
            ContentType = contentType;
            FilePath = filePath;
        }

        public void AddFilePath(string filePath)
        {
            FilePath = filePath;
        }
    }
}
