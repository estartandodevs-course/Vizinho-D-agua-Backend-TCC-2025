namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create
{
    public class CreateEducationContentResponse
    {
        public string Title { get; private set; }
        public string? Image { get; private set; }
        public string? Author { get; private set; }
        public string ContentType { get; private set; }

        public CreateEducationContentResponse(string title, string? image, string? author, string contentType)
        {
            Title = title;
            Image = image;
            Author = author;
            ContentType = contentType;
        }
    }
}
