namespace VizinhoDAgua.Application.UseCases.User.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadProfileImageCommandResponse
    {
        public string PresignedUrl { get; private set; }

        public GeneratePresignedForUploadProfileImageCommandResponse(string presignedUrl)
        {
            PresignedUrl = presignedUrl;
        }
    }
}
