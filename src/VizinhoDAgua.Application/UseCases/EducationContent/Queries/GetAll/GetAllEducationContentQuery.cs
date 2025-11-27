using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetAll
{
    public class GetAllEducationContentQuery : IRequest<CommandResponse<GetAllEducationContentQueryResponse>>
    {
    }
}
