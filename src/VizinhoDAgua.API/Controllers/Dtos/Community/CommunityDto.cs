namespace VizinhoDAgua.API.Controllers.Dtos.Community
{
    public record CreateCommunityRequest(string Title, string Description, string? CoverImage) {}
    public record UpdateCommunityRequest(string? Title, string? Description, string? CoverImage) {}
}
