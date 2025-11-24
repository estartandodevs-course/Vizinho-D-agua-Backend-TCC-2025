namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create
{
    public class CreateEducationContentResponse
    {
        public Guid Id { get; private set; }

        public CreateEducationContentResponse(Guid id)
        {
            Id = id;
        }
    }
}
