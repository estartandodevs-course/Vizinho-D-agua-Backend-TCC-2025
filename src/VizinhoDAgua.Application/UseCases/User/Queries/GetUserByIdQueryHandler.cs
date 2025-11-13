using MediatR;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse?>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResponse?> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(query.Id);
            if (user == null) return null;

            return new GetUserByIdQueryResponse
            (
                user.Id,
                user.Name,
                user.Email,
                user.IsAdmin,
                user.ProfileImage
            );
        }
    }
}