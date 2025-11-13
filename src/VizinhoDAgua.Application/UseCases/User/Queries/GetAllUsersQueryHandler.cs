using MediatR;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersQueryResponse>>
    {
        private readonly IUserRepository _repository;
    
        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<IEnumerable<GetAllUsersQueryResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
    
            // transforma cada user do banco num objeto de resposta (DTO)
            return users.Select(user => new GetAllUsersQueryResponse
            (
                user.Id,
                user.Name,
                user.Email,
                user.IsAdmin,
                user.ProfileImage
            ));
        }
    }
}
