using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Queries.GetAll
{
    public class GetAllCommunitiesPostQuery : IRequest<CommandResponse<GetAllCommunitiesPostQueryResponse>>
    {
    }
}
