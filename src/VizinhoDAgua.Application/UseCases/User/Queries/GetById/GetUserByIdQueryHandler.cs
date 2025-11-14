using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<
        GetUserByIdQuery, CommandResponse<GetUserByIdQueryResponse>>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse<GetUserByIdQueryResponse>> Handle(
            GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (!request.Validade())
                return CommandResponse<GetUserByIdQueryResponse>.ValidationError(request.ValidationResult);

            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
                return CommandResponse<GetUserByIdQueryResponse>.AddError(message: "Usuário não encontrado.",
                    statusCode: HttpStatusCode.NotFound);

            return CommandResponse<GetUserByIdQueryResponse>.Success(
                new GetUserByIdQueryResponse(user), HttpStatusCode.OK);
        }
    }
}