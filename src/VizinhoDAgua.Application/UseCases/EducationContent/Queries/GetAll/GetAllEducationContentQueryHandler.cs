using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetAll
{
    public class GetAllEducationContentQueryHandler
        : GetAllQueryHandler<EducationContentEntity, GetAllEducationContentQuery, GetAllEducationContentQueryResponse>
    {
        private readonly IAwsS3Service _awsS3Service;

        public GetAllEducationContentQueryHandler(IEducationContentRepository educationContentRepository, IMapper mapper, IAwsS3Service awsS3Service)
            : base(educationContentRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GetAllEducationContentQueryResponse>> Handle(GetAllEducationContentQuery request, CancellationToken cancellationToken)
        {
            var educationContents = await _repository.GetAllAsync();

            var educationContentsWithProfileImage = educationContents.Select(async educationContent =>
            {
                if (string.IsNullOrEmpty(educationContent.FilePath))
                    return educationContent;

                var profileImage = await _awsS3Service.GeneratePresignedUrlDownloadAsync
                (
                    $"educationContents/{educationContent.Id}/{educationContent.FilePath}", educationContent.FilePath ?? string.Empty
                );

                educationContent.AddFilePath(profileImage);

                return educationContent;
            });

            var educationContentsWithProfileImageResolved = await Task.WhenAll(educationContentsWithProfileImage);

            var response = _mapper.Map<GetAllEducationContentQueryResponse>(educationContents);

            return CommandResponse<GetAllEducationContentQueryResponse>.Success(response, HttpStatusCode.OK);
        }
    }
}
