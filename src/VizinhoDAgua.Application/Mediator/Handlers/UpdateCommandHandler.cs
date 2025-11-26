using AutoMapper;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Repositories.Abstractions;

namespace VizinhoDAgua.Application.Mediator.Handlers
{
    public abstract class UpdateCommandHandler<TEntity, TCommand>
        : IRequestHandler<TCommand, CommandResponse<Unit>>
        where TEntity : Entity
        where TCommand : IRequestWithValidationAndId<Unit>
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        public UpdateCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        // Aplica a atualização na entidade ~> Pode ser sobrescrito para lógica customizada.
        protected virtual void ApplyUpdate(TCommand request, TEntity entity)
        {
            Mapper.Map(request, entity);
        }

        public async Task<CommandResponse<Unit>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);

            var entity = await Repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CommandResponse<Unit>.AddError(
                    message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound
                );

            // Substitui o mapping direto pelo método extensível
            ApplyUpdate(request, entity);

            await Repository.UpdateAsync(entity);
            return CommandResponse<Unit>.Success(Unit.Value, HttpStatusCode.OK);
        }
    }
}
