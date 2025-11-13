using MediatR;

namespace VizinhoDAgua.Application.UseCases.User.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersQueryResponse>>
    {
    }
}
