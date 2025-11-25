using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Community.Query.GetAll
{
    public class GetAllCommunitiesQuery : IRequest<CommandResponse<GetAllCommunitiesQueryResponse>>
    {
    }
}
