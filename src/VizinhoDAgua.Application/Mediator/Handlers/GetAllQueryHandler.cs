using AutoMapper;
using MediatR;
using System.Net;
using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Repositories.Abstractions;

namespace VizinhoDAgua.Application.Mediator.Handlers
{
    public abstract class GetAllQueryHandler<TEntity, TQuery, TGetAllQueryResponse>
        : IRequestHandler<TQuery, CommandResponse<TGetAllQueryResponse>>
        where TEntity : Entity
        where TQuery : IRequest<CommandResponse<TGetAllQueryResponse>>
        where TGetAllQueryResponse : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GetAllQueryHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<TGetAllQueryResponse>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var communities = await _repository.GetAllAsync();

            return CommandResponse<TGetAllQueryResponse>.Success(_mapper.Map<TGetAllQueryResponse>(communities), HttpStatusCode.OK);
        }
    }
}
