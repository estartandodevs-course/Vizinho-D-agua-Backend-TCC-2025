using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadFileCommandHandler
        : UpdateCommandHandlerWithReturn<EducationContentEntity, GeneratePresignedForUploadFileCommand, GeneratePresignedForUploadFileCommandResponse>
    {
        private readonly IAwsS3Service _awsS3Service;
        protected override GeneratePresignedForUploadFileCommandResponse response { get; set; } = null!;

        public GeneratePresignedForUploadFileCommandHandler(IEducationContentRepository educationContentRepository, IMapper mapper, IAwsS3Service awsS3Service)
            : base(educationContentRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GeneratePresignedForUploadFileCommandResponse>> Handle(GeneratePresignedForUploadFileCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<GeneratePresignedForUploadFileCommandResponse>.ValidationError(request.ValidationResult);

            var educationContent = await _repository.GetByIdAsync(request.Id);
            if (educationContent == null)
                return CommandResponse<GeneratePresignedForUploadFileCommandResponse>
                    .AddError(message: "Conteúdo educacional não encontrado.", statusCode: HttpStatusCode.NotFound);

            if (request.FileName == educationContent.FilePath)
                return CommandResponse<GeneratePresignedForUploadFileCommandResponse>
                    .AddError(message: "O nome do arquivo não pode ser igual ao encontrado em conteúdo educacional.", statusCode: HttpStatusCode.Conflict);

            var filePathInS3 = $"educationContents/{educationContent.Id}/{request.FileName}";

            var presignedUrl = await GeneratePresignedUrlForUpload(filePathInS3, request.FileName);

            educationContent.AddFilePath(request.FileName);
            await _repository.UpdateAsync(educationContent);

            response = new GeneratePresignedForUploadFileCommandResponse(presignedUrl);

            return CommandResponse<GeneratePresignedForUploadFileCommandResponse>
                .Success(response, HttpStatusCode.OK);
        }

        private async Task<string> GeneratePresignedUrlForUpload(string filePathInS3, string fileName)
        {
            var presignedUrl = await _awsS3Service.GeneratePresignedUrlUploadAsync(filePathInS3, fileName);
            return presignedUrl;
        }


    }
}
