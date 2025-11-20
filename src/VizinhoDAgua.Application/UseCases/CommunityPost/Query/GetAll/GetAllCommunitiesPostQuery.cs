using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Query.GetAll
{
    public class GetAllCommunitiesPostQuery : IRequest<CommandResponse<GetAllCommunitiesPostQueryResponse>>
    {
    }
}
