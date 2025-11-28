using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Report.Queries.GetById;

public class GetReportByIdQueryHandler
    : GetByIdQueryHandler<ReportEntity, GetReportByIdQuery, GetReportByIdQueryResponse>
{
    private readonly IAwsS3Service _awsS3Service;

    public GetReportByIdQueryHandler(IReportRepository reportRepository, IMapper mapper, IAwsS3Service awsS3Service)
        : base(reportRepository, mapper)
    {
        _awsS3Service = awsS3Service;
    }

    public override async Task<CommandResponse<GetReportByIdQueryResponse>> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
    {
        var report = await _repository.GetByIdAsync(request.Id);
        if (report == null)
            return CommandResponse<GetReportByIdQueryResponse>.AddError(message: "Denúncia não encontrada.", statusCode: HttpStatusCode.NotFound);

        if (report.Attachments.Count != 0)
        {
            var attachmentsWithPresignedUrl = report.Attachments.Select(async attachment =>
                {
                    var presignedUrl = await _awsS3Service.GeneratePresignedUrlDownloadAsync
                    (
                        $"reports/{report.Id}/{attachment}", attachment ?? string.Empty
                    );

                    return presignedUrl;
                });

            var attachmentsWithPresignedUrlResolved = await Task.WhenAll(attachmentsWithPresignedUrl);

            report.UpdateAttachmentList([.. attachmentsWithPresignedUrlResolved]);
        }

        var reponse = _mapper.Map<GetReportByIdQueryResponse>(report);

        return CommandResponse<GetReportByIdQueryResponse>.Success(reponse, HttpStatusCode.OK);
    }
}
