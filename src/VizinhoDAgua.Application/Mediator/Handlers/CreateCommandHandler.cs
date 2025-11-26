using AutoMapper;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Repositories.Abstractions;

namespace VizinhoDAgua.Application.Mediator.Handlers
{
    public abstract class CreateCommandHandler<TEntity, TCommand, TCreateCommandResponse> 
        : IRequestHandler<TCommand, CommandResponse<TCreateCommandResponse>>
        where TEntity : Entity
        where TCommand : IRequestWithValidation<TCreateCommandResponse>
        where TCreateCommandResponse : class
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        public CreateCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        // Customização nos handles específicos
        protected virtual Task BeforeCreateAsync(TCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task<CommandResponse<TCreateCommandResponse>> Handle(
            TCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<TCreateCommandResponse>.ValidationError(request.ValidationResult);

            try
            {
                // regra customizada
                await BeforeCreateAsync(request, cancellationToken);

                var entity = Mapper.Map<TEntity>(request);

                await Repository.AddAsync(entity);

                var response = Mapper.Map<TCreateCommandResponse>(entity.Id);

                return CommandResponse<TCreateCommandResponse>.Success(response, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return CommandResponse<TCreateCommandResponse>.CriticalError(
                    $"Ocorreu um erro ao criar a entidade: {ex.Message}"
                );
            }
        }
    }
}
