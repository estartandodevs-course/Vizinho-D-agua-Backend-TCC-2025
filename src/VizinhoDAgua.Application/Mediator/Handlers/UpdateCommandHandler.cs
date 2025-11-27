using AutoMapper;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Repositories.Abstractions;

namespace VizinhoDAgua.Application.Mediator.Handlers
{
    public abstract class UpdateCommandHandlerWithReturn<TEntity, TCommand, TUpdateCommandResponse>
        : IRequestHandler<TCommand, CommandResponse<TUpdateCommandResponse>>
        where TEntity : Entity
        where TCommand : IRequestWithValidationAndId<TUpdateCommandResponse>
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected abstract TUpdateCommandResponse response { get; set; }

        public UpdateCommandHandlerWithReturn(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<CommandResponse<TUpdateCommandResponse>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<TUpdateCommandResponse>.ValidationError(request.ValidationResult);

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CommandResponse<TUpdateCommandResponse>.AddError(message: "entidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);

            response = _mapper.Map<TUpdateCommandResponse>(entity);

            return CommandResponse<TUpdateCommandResponse>.Success(response, HttpStatusCode.OK);
        }
    }

    public abstract class UpdateCommandHandler<TEntity, TCommand>
        : UpdateCommandHandlerWithReturn<TEntity, TCommand, Unit>
        where TEntity : Entity
        where TCommand : IRequestWithValidationAndId<Unit>
    {
        protected override Unit response { get; set; }

        public UpdateCommandHandler(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {
            response = Unit.Value;
        }

        public override async Task<CommandResponse<Unit>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CommandResponse<Unit>.AddError(message: "entidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);

            return CommandResponse<Unit>.Success(response, HttpStatusCode.OK);
        }
    }
}
