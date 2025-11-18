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
        private readonly IRepository<TEntity> _communityRepository;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(IRepository<TEntity> communityRepository, IMapper mapper)
        {
            _communityRepository = communityRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<Unit>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);

            var entity = await _communityRepository.GetByIdAsync(request.Id);
            if (entity == null)
                return CommandResponse<Unit>.AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            _mapper.Map(request, entity);

            await _communityRepository.UpdateAsync(entity);

            return CommandResponse<Unit>.Success(Unit.Value, HttpStatusCode.OK);
        }
    }
}
