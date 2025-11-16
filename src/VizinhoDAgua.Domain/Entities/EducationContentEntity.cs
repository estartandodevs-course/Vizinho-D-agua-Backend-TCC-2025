namespace VizinhoDAgua.Domain.Entities
{
    public class EducationContentEntity : Entity
    {

        public string Title { get; private set; } = string.Empty;
        public string Image { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        public string ContentType { get; private set; }

        public EducationContentEntity() { } // EF Core

        public EducationContentEntity(string? title, string? image, string? author, string? contentType)
        {
            Title = title;
            Image = image;
            Author = author;
            ContentType = contentType;
        }
    }
}