using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, CommandResponse<Unit>>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse<Unit>> Handle(
            UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);
            
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
                return CommandResponse<Unit>.AddError(message: "Usuário não encontrado", HttpStatusCode.NotFound);

            user.Update(request.Name, request.ProfileImage);
            
            await _repository.UpdateAsync(user);
            return CommandResponse<Unit>.Success(Unit.Value, HttpStatusCode.OK);
        }
    }
}
