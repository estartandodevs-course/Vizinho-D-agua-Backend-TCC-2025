using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Communities.Command.Update
{
    public class UpdateCommunityCommandHandler
     (
         ICommunityRepository communityRepository
     ) : IRequestHandler<UpdateCommunityCommand, CommandResponse<Unit>>
    {
        private readonly ICommunityRepository _communityRepository = communityRepository;

        public async Task<CommandResponse<Unit>> Handle(UpdateCommunityCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ErrorValidation(request.validationResult);

            var community = await _communityRepository.GetByIdAsync(request.Id);
            if (community == null)
                return CommandResponse<Unit>.AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            await _communityRepository.UpdateAsync(community);

            return CommandResponse<Unit>.Success(null);
            
        }
    }
}
