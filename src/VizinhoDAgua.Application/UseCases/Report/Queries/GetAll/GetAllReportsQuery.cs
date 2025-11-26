using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Report.Queries.GetAll
{
    public class GetAllReportsQuery : IRequest<CommandResponse<GetAllReportsQueryResponse>>
    {
    }
}
