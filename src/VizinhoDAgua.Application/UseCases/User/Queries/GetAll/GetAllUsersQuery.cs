using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<CommandResponse<GetAllUsersQueryResponse>>
    {
    }
}
