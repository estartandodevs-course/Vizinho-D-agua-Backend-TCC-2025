namespace VizinhoDAgua.Application.UseCases.User.Commands
{
    // DTO de resposta
    public class CreateUserCommandResponse
    {
        public Guid Id { get; private set; }

        public CreateUserCommandResponse(Guid id)
        {
            Id = id;
        }
    }
}
