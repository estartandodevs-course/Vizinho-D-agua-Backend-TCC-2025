using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Community.Queries.GetById
{
    public class GetCommunityByIdQueryHandler : GetByIdQueryHandler<CommunityEntity, GetCommunityByIdQuery, GetCommunityByIdQueryResponse>
    {
        private readonly IAwsS3Service _awsS3Service;

        public GetCommunityByIdQueryHandler(ICommunityRepository communityRepository, IMapper mapper, IAwsS3Service awsS3Service) : base(communityRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GetCommunityByIdQueryResponse>> Handle(GetCommunityByIdQuery request, CancellationToken cancellationToken)
        {
            var community = await _repository.GetByIdAsync(request.Id);
            if (community == null)
                return CommandResponse<GetCommunityByIdQueryResponse>.AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            if (!string.IsNullOrEmpty(community.CoverImage))
            {
                var coverImage = await _awsS3Service.GeneratePresignedUrlDownloadAsync(
                    $"communities/{community.Id}/{community.CoverImage}",
                    community.CoverImage);

                community.AddCoverImage(coverImage);
            }

            var response = _mapper.Map<GetCommunityByIdQueryResponse>(community);

            return CommandResponse<GetCommunityByIdQueryResponse>.Success(response, HttpStatusCode.OK);
        }
    }
}
