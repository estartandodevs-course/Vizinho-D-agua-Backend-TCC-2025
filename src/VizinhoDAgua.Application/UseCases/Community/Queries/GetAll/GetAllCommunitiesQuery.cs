using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Community.Queries.GetAll
{
    public class GetAllCommunitiesQuery : IRequest<CommandResponse<GetAllCommunitiesQueryResponse>>
    {
    }
}
