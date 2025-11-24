namespace VizinhoDAgua.Application.Dtos
{
    public record CreateCommunityPostRequest(Guid AuthorId, Guid CommunityId, string Content, List<string>? Images) {}
    public record UpdateCommunityPostRequest(string? Content, List<string>? Images) {}
}