namespace VizinhoDAgua.Application.UseCases.Community.Command.Create
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
