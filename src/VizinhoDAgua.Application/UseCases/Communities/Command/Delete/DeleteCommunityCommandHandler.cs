using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Communities.Command.Delete
{
    public class DeleteCommunityCommandHandler : IRequestHandler<DeleteCommunityCommand, CommandResponse<Unit>>
    {
        private readonly ICommunityRepository _communityRepository;

        public DeleteCommunityCommandHandler(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }

        public async Task<CommandResponse<Unit>> Handle(DeleteCommunityCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);

            var community = await _communityRepository.GetByIdAsync(request.Id);
            if (community == null)
                return CommandResponse<Unit>.AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            await _communityRepository.DeleteAsync(community.Id);

            return CommandResponse<Unit>.Success(Unit.Value, HttpStatusCode.NoContent);
            
        }
    }
}
