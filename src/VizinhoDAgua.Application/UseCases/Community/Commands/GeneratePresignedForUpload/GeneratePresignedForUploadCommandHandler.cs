using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Community.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadCommandHandler
        : UpdateCommandHandlerBase<CommunityEntity, GeneratePresignedForUploadCommand, GeneratePresignedForUploadCommandResponse>
    {
        private readonly IAwsS3Service _awsS3Service;
        protected override GeneratePresignedForUploadCommandResponse response { get; set; } = null!;

        public GeneratePresignedForUploadCommandHandler(ICommunityRepository communityRepository, IMapper mapper, IAwsS3Service awsS3Service)
            : base(communityRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GeneratePresignedForUploadCommandResponse>> Handle(GeneratePresignedForUploadCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<GeneratePresignedForUploadCommandResponse>.ValidationError(request.ValidationResult);

            var community = await _repository.GetByIdAsync(request.Id);
            if (community == null)
                return CommandResponse<GeneratePresignedForUploadCommandResponse>
                    .AddError(message: "Comunidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            if (request.FileName == community.CoverImage)
                return CommandResponse<GeneratePresignedForUploadCommandResponse>
                    .AddError(message: "O nome do arquivo não pode ser igual ao da imagem de capa atual.", statusCode: HttpStatusCode.Conflict);

            var filePathInS3 = $"communities/{community.Id}/{request.FileName}";

            var presignedUrl = await GeneratePresignedUrlForUpload(filePathInS3, request.FileName);

            community.AddCoverImage(request.FileName);
            await _repository.UpdateAsync(community);

            response = new GeneratePresignedForUploadCommandResponse(presignedUrl);

            return CommandResponse<GeneratePresignedForUploadCommandResponse>
                .Success(response, HttpStatusCode.OK);
        }

        private async Task<string> GeneratePresignedUrlForUpload(string filePathInS3, string fileName)
        {
            var presignedUrl = await _awsS3Service.GeneratePresignedUrlUploadAsync(filePathInS3, fileName);
            return presignedUrl;
        }


    }
}
