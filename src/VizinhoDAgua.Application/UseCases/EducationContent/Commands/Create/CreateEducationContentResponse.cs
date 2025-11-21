using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create
{
    public class CreateEducationContentResponse
    {
        public string Title { get; private set; }
        public string? Image { get; private set; }
        public string Author { get; private set; }
        public EducationContentType ContentType { get; private set; }
        public string? FilePath { get; private set; }

        public CreateEducationContentResponse(string title, string? image, string author, 
            EducationContentType contentType, string? filePath)
        {
            Title = title;
            Image = image;
            Author = author;
            ContentType = contentType;
            FilePath = filePath;
        }
    }
}
