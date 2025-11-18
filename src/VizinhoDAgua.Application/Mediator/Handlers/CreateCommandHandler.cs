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
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<TCreateCommandResponse>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<TCreateCommandResponse>.ValidationError(request.ValidationResult);

            try
            {
                var entity = _mapper.Map<TEntity>(request);

                await _repository.AddAsync(entity);

                var response = _mapper.Map<TCreateCommandResponse>(entity.Id);

                return CommandResponse<TCreateCommandResponse>.Success(response, statusCode: HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return CommandResponse<TCreateCommandResponse>.CriticalError(message: $"Ocorreu um erro ao criar a entidade: {ex.Message}");
            }
        }
    }
}
