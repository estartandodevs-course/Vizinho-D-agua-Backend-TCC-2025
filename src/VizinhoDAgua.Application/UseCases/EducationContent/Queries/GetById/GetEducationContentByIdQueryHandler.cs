using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetById
{
    public class GetEducationContentByIdQueryHandler
        : GetByIdQueryHandler<EducationContentEntity, GetEducationContentByIdQuery, GetEducationContentByIdQueryResponse>
    {
        private readonly IAwsS3Service _awsS3Service;

        public GetEducationContentByIdQueryHandler(IEducationContentRepository educationContentRepository, IMapper mapper, IAwsS3Service awsS3Service)
            : base(educationContentRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GetEducationContentByIdQueryResponse>> Handle(GetEducationContentByIdQuery request, CancellationToken cancellationToken)
        {
            var educationContent = await _repository.GetByIdAsync(request.Id);
            if (educationContent == null)
                return CommandResponse<GetEducationContentByIdQueryResponse>.AddError(message: "Conteúdo educacional não encontrado.", statusCode: HttpStatusCode.NotFound);

            if (!string.IsNullOrEmpty(educationContent.FilePath))
            {
                var profileImage = await _awsS3Service.GeneratePresignedUrlDownloadAsync(
                    $"educationContents/{educationContent.Id}/{educationContent.FilePath}",
                    educationContent.FilePath ?? string.Empty);

                educationContent.AddFilePath(profileImage);
            }

            var response = _mapper.Map<GetEducationContentByIdQueryResponse>(educationContent);

            return CommandResponse<GetEducationContentByIdQueryResponse>.Success(response, HttpStatusCode.OK);
        }
    }
}
