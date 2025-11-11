namespace VizinhoDAgua.Application.UseCases.Communities.Command.Create
{
    public class CreateCommunityCommandResponse(Guid id)
    {
        public Guid Id { get; private set; } = id;
    }
}
