namespace VizinhoDAgua.Application.UseCases.Report.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadAttachmentCommandResponse
    {
        public string PresignedUrl { get; private set; }

        public GeneratePresignedForUploadAttachmentCommandResponse(string presignedUrl)
        {
            PresignedUrl = presignedUrl;
        }
    }
}
