using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Community.Queries.GetAll
{
    public class GetAllCommunitiesQueryHandler : GetAllQueryHandler<CommunityEntity, GetAllCommunitiesQuery, GetAllCommunitiesQueryResponse>
    {
        private readonly IAwsS3Service _awsS3Service;

        public GetAllCommunitiesQueryHandler(ICommunityRepository communityRepository, IMapper mapper, IAwsS3Service awsS3Service) : base(communityRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GetAllCommunitiesQueryResponse>> Handle(GetAllCommunitiesQuery request, CancellationToken cancellationToken)
        {
            var communities = await _repository.GetAllAsync();

            var communitiesWithImages = communities.Select(async community =>
            {
                if (string.IsNullOrEmpty(community.CoverImage))
                    return community;

                var coverImage = await _awsS3Service.GeneratePresignedUrlDownloadAsync
                (
                    $"communities/{community.Id}/{community.CoverImage}", community.CoverImage ?? string.Empty
                );

                community.AddCoverImage(coverImage);

                return community;
            });

            var communitiesWithImagesResolved = await Task.WhenAll(communitiesWithImages);

            var response = _mapper.Map<GetAllCommunitiesQueryResponse>(communitiesWithImagesResolved);

            return CommandResponse<GetAllCommunitiesQueryResponse>.Success(response, HttpStatusCode.OK);
        }
    }
}
