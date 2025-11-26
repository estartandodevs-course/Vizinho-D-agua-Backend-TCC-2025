namespace VizinhoDAgua.Application.UseCases.Community.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadCommandResponse
    {
        public string PresignedUrl { get; private set; }

        public GeneratePresignedForUploadCommandResponse(string presignedUrl)
        {
            PresignedUrl = presignedUrl;
        }
    }
}
