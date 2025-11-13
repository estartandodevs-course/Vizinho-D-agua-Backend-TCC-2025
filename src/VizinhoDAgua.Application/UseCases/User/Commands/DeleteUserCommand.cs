using MediatR;

namespace VizinhoDAgua.Application.UseCases.User.Commands
{
    // DTO de entrada para deletar o usuário
    public class DeleteUserCommand : IRequest<bool>
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
