using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Communities.Query.GetAll
{
    public class GetAllCommunitiesQuery : IRequest<CommandResponse<GetAllCommunitiesQueryResponse>>
    {
    }
}
