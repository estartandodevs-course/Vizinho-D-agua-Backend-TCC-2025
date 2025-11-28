using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadAttachmentCommandHandler
        : UpdateCommandHandlerWithReturn<ReportEntity, GeneratePresignedForUploadAttachmentCommand, GeneratePresignedForUploadAttachmentCommandResponse>
    {
        private readonly IAwsS3Service _awsS3Service;
        protected override GeneratePresignedForUploadAttachmentCommandResponse response { get; set; } = null!;

        public GeneratePresignedForUploadAttachmentCommandHandler(IReportRepository reportRepository, IMapper mapper, IAwsS3Service awsS3Service)
            : base(reportRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GeneratePresignedForUploadAttachmentCommandResponse>> Handle(GeneratePresignedForUploadAttachmentCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<GeneratePresignedForUploadAttachmentCommandResponse>.ValidationError(request.ValidationResult);

            var report = await _repository.GetByIdAsync(request.Id);
            if (report == null)
                return CommandResponse<GeneratePresignedForUploadAttachmentCommandResponse>
                    .AddError(message: "Usuário não encontrado.", statusCode: HttpStatusCode.NotFound);

            var filePathInS3 = $"reports/{report.Id}/{request.FileName}";

            var presignedUrl = await GeneratePresignedUrlForUpload(filePathInS3, request.FileName);

            report.AddAttachment(request.FileName);
            await _repository.UpdateAsync(report);

            response = new GeneratePresignedForUploadAttachmentCommandResponse(presignedUrl);

            return CommandResponse<GeneratePresignedForUploadAttachmentCommandResponse>
                .Success(response, HttpStatusCode.OK);
        }

        private async Task<string> GeneratePresignedUrlForUpload(string filePathInS3, string fileName)
        {
            var presignedUrl = await _awsS3Service.GeneratePresignedUrlUploadAsync(filePathInS3, fileName);
            return presignedUrl;
        }


    }
}
