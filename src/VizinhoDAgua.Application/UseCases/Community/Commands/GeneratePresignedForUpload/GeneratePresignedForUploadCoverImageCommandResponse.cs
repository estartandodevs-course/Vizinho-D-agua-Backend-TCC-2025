namespace VizinhoDAgua.Application.UseCases.Community.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadCoverImageCommandResponse
    {
        public string PresignedUrl { get; private set; }

        public GeneratePresignedForUploadCoverImageCommandResponse(string presignedUrl)
        {
            PresignedUrl = presignedUrl;
        }
    }
}
