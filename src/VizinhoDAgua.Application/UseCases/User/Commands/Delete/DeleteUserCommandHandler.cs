using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, CommandResponse<Unit>>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse<Unit>> Handle(
            DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);
            
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
                return CommandResponse<Unit>.AddError(message: "Usuário não encontrado.", HttpStatusCode.NotFound);

            await _repository.DeleteAsync(user.Id);
            return CommandResponse<Unit>.Success(Unit.Value, HttpStatusCode.NoContent);
        }
    }
}
