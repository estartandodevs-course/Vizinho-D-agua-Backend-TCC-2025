namespace VizinhoDAgua.Application.UseCases.Community.Query.GetById
{
    public class GetCommunityByIdQueryResponse
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string? CoverImage { get; private set; }

        public GetCommunityByIdQueryResponse(Domain.Entities.Community community)
        {
            Id = community.Id;
            Title = community.Title;
            Description = community.Description;
            CoverImage = community.CoverImage;
        }
    }
}
