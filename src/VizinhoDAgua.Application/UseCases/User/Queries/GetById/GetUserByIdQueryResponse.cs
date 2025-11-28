using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetById
{
    public class GetUserByIdQueryResponse
    {
        public UserEntity User { get; }

        public GetUserByIdQueryResponse(UserEntity user)
        {
            User = user;
        }
    }
}
