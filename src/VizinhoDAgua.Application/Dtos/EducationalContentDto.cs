using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.Dtos
{
    public record CreateEducationalContentRequest(string Title, string? Image, string Author, 
        EducationContentType ContentType, string? FilePath){}
    public record UpdateEducationalContentRequest(string Title, string? Image, string Author, string? FilePath){}
}
