using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Repositories.Abstractions;

namespace VizinhoDAgua.Application.Mediator.Handlers
{
    public abstract class DeleteCommandHandler<TEntity, TCommand>
        : IRequestHandler<TCommand, CommandResponse<Unit>>
        where TEntity : Entity
        where TCommand : IRequestWithValidationAndId<Unit>
    {
        protected readonly IRepository<TEntity> _repository;

        public DeleteCommandHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse<Unit>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CommandResponse<Unit>.AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            await _repository.DeleteAsync(entity.Id);

            return CommandResponse<Unit>.Success(Unit.Value, HttpStatusCode.NoContent);
        }
    }
}
