namespace VizinhoDAgua.Application.UseCases.Community.Commands.Create
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
