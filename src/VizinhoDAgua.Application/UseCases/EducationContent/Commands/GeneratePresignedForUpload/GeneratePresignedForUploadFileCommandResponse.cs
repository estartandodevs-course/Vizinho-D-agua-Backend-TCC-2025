namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadFileCommandResponse
    {
        public string PresignedUrl { get; private set; }

        public GeneratePresignedForUploadFileCommandResponse(string presignedUrl)
        {
            PresignedUrl = presignedUrl;
        }
    }
}
