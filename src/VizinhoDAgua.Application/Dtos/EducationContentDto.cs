using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.Dtos
{
    public record CreateEducationContentRequest(string Title, string? Image, string Author, 
        EducationContentType ContentType, string? FilePath){}
    public record UpdateEducationContentRequest(string Title, string? Image, string Author,
        EducationContentType ContentType, string? FilePath){}
}
