namespace VizinhoDAgua.Application.Mediator.IRequests
{
    public interface IRequestWithValidationAndId<ICommandResponse> : IRequestWithValidation<ICommandResponse>
    {
        public Guid Id { get; }
    }
}
