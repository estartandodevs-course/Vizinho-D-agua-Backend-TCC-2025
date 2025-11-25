namespace VizinhoDAgua.Application.UseCases.Report.Commands.Create
{
    public class CreateReportCommandResponse
    {
        public Guid Id { get; private set; }

        public CreateReportCommandResponse(Guid id)
        {
            Id = id;
        }
    }
}
