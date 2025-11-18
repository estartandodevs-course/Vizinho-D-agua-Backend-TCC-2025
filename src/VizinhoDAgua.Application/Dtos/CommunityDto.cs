namespace VizinhoDAgua.Application.Dtos
{
    public record CreateCommunityRequest(string Title, string Description, string? CoverImage) {}
    public record UpdateCommunityRequest(string? Title, string? Description, string? CoverImage) {}
}
