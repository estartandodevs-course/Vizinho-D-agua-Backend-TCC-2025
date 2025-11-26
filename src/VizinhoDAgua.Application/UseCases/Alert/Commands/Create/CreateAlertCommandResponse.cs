namespace VizinhoDAgua.Application.UseCases.Alert.Commands.Create
{
    public class CreateAlertCommandResponse
    {
        public Guid Id { get; private set; }

        public CreateAlertCommandResponse(Guid id)
        {
            Id = id;
        }
    }
}
