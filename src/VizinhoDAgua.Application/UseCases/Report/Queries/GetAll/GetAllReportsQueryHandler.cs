using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Report.Queries.GetAll
{
    public class GetAllReportsQueryHandler
        : GetAllQueryHandler<ReportEntity, GetAllReportsQuery, GetAllReportsQueryResponse>
    {
        private readonly IAwsS3Service _awsS3Service;

        public GetAllReportsQueryHandler(IReportRepository reportRepository, IMapper mapper, IAwsS3Service awsS3Service)
            : base(reportRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GetAllReportsQueryResponse>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await _repository.GetAllAsync();

            var reportsWithAttachment = reports.Select(async report =>
            {
                if (report.Attachments.Count == 0)
                    return report;

                var attachments = report.Attachments.Select(async attachment =>
                    {
                        var presignedUrl = await _awsS3Service.GeneratePresignedUrlDownloadAsync
                        (
                            $"reports/{report.Id}/{attachment}", attachment ?? string.Empty
                        );

                        return presignedUrl;
                    });

                var attachmentsWithPresignedUrl = await Task.WhenAll(attachments);

                report.UpdateAttachmentList([.. attachmentsWithPresignedUrl]);

                return report;
            });

            var reportsWithAttachmentResolved = await Task.WhenAll(reportsWithAttachment);

            var response = _mapper.Map<GetAllReportsQueryResponse>(reports);

            return CommandResponse<GetAllReportsQueryResponse>.Success(response, HttpStatusCode.OK);
        }
    }
}
