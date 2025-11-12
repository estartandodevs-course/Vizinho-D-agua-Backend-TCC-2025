namespace VizinhoDAgua.Application.UseCases.Communities.Command.Create
{
    public class CreateCommunityCommandResponse
    {
        public Guid Id { get; private set; }

        public CreateCommunityCommandResponse(Guid id)
        {
            Id = id;
        }
    }
}
