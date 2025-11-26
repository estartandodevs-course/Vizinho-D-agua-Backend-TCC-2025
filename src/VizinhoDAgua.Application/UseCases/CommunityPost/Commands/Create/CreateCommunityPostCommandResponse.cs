namespace VizinhoDAgua.Application.UseCases.CommunityPost.Command.Create
{
    public class CreateCommunityPostCommandResponse
    {
        public Guid Id { get; private set; }

        public CreateCommunityPostCommandResponse(Guid id)
        {
            Id = id;
        }
    }
}
