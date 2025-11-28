using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Community.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadCoverImageCommandHandler
        : UpdateCommandHandlerWithReturn<CommunityEntity, GeneratePresignedForUploadCoverImageCommand, GeneratePresignedForUploadCoverImageCommandResponse>
    {
        private readonly IAwsS3Service _awsS3Service;
        protected override GeneratePresignedForUploadCoverImageCommandResponse response { get; set; } = null!;

        public GeneratePresignedForUploadCoverImageCommandHandler(ICommunityRepository communityRepository, IMapper mapper, IAwsS3Service awsS3Service)
            : base(communityRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GeneratePresignedForUploadCoverImageCommandResponse>> Handle(GeneratePresignedForUploadCoverImageCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<GeneratePresignedForUploadCoverImageCommandResponse>.ValidationError(request.ValidationResult);

            var community = await _repository.GetByIdAsync(request.Id);
            if (community == null)
                return CommandResponse<GeneratePresignedForUploadCoverImageCommandResponse>
                    .AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            if (request.FileName == community.CoverImage)
                return CommandResponse<GeneratePresignedForUploadCoverImageCommandResponse>
                    .AddError(message: "O nome do arquivo não pode ser igual ao da imagem de capa atual.", statusCode: HttpStatusCode.Conflict);

            var filePathInS3 = $"communities/{community.Id}/{request.FileName}";

            var presignedUrl = await GeneratePresignedUrlForUpload(filePathInS3, request.FileName);

            community.AddCoverImage(request.FileName);
            await _repository.UpdateAsync(community);

            response = new GeneratePresignedForUploadCoverImageCommandResponse(presignedUrl);

            return CommandResponse<GeneratePresignedForUploadCoverImageCommandResponse>
                .Success(response, HttpStatusCode.OK);
        }

        private async Task<string> GeneratePresignedUrlForUpload(string filePathInS3, string fileName)
        {
            var presignedUrl = await _awsS3Service.GeneratePresignedUrlUploadAsync(filePathInS3, fileName);
            return presignedUrl;
        }


    }
}
