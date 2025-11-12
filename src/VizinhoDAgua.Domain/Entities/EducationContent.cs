namespace VizinhoDAgua.Domain.Entities
{
    public class EducationContent : Entity
    {

        public string Title { get; private set; } = string.Empty;
        public string Image { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        public string ContentType { get; private set; }

        public EducationContent() { } // EF Core

        public EducationContent(string? title, string? image, string? author, string? contentType)
        {
            Title = title;
            Image = image;
            Author = author;
            ContentType = contentType;
        }
    }
}