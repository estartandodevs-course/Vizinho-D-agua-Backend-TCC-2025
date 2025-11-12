using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Communities.Query.GetById
{
    public class GetCommunityByIdQueryHandler : IRequestHandler<GetCommunityByIdQuery, CommandResponse<GetCommunityByIdQueryResponse>>
    {
        private readonly ICommunityRepository _communityRepository;

        public GetCommunityByIdQueryHandler(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }

        public async Task<CommandResponse<GetCommunityByIdQueryResponse>> Handle(GetCommunityByIdQuery request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<GetCommunityByIdQueryResponse>.ValidationError(request.ValidationResult);

            var community = await _communityRepository.GetByIdAsync(request.Id);
            if (community == null)
                return CommandResponse<GetCommunityByIdQueryResponse>.AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            return CommandResponse<GetCommunityByIdQueryResponse>.Success(new GetCommunityByIdQueryResponse(community), HttpStatusCode.OK);
        }
    }
}
