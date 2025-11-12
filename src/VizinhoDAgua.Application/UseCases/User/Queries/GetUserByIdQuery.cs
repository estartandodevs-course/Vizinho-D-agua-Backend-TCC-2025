using MediatR;

namespace VizinhoDAgua.Application.UseCases.User.Queries
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
