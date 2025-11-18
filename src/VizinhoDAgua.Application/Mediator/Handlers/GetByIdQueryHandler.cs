using AutoMapper;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Repositories.Abstractions;

namespace VizinhoDAgua.Application.Mediator.Handlers
{
    public abstract class GetByIdQueryHandler<TEntity, TQuery, TGetByIdQueryResponse>
        : IRequestHandler<TQuery, CommandResponse<TGetByIdQueryResponse>>
        where TEntity : Entity
        where TQuery : IRequestWithValidationAndId<TGetByIdQueryResponse>
        where TGetByIdQueryResponse : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<TGetByIdQueryResponse>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<TGetByIdQueryResponse>.ValidationError(request.ValidationResult);

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CommandResponse<TGetByIdQueryResponse>.AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            return CommandResponse<TGetByIdQueryResponse>.Success(_mapper.Map<TGetByIdQueryResponse>(entity), HttpStatusCode.OK);
        }
    }
}
