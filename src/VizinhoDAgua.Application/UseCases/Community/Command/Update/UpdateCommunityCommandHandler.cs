using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Community.Command.Update
{
    public class UpdateCommunityCommandHandler : IRequestHandler<UpdateCommunityCommand, CommandResponse<Unit>>
    {
        private readonly ICommunityRepository _communityRepository;

        public UpdateCommunityCommandHandler(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }

        public async Task<CommandResponse<Unit>> Handle(UpdateCommunityCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);

            var community = await _communityRepository.GetByIdAsync(request.Id);
            if (community == null)
                return CommandResponse<Unit>.AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            await _communityRepository.UpdateAsync(community);

            return CommandResponse<Unit>.Success(Unit.Value, HttpStatusCode.OK);
        }
    }
}
