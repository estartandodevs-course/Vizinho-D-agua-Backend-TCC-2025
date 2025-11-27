namespace VizinhoDAgua.Infrastructure.Cloud.Interfaces
{
    public interface IAwsS3Service
    {
        Task<string> GeneratePresignedUrlUploadAsync(string path, string fileName);
        Task<string> GeneratePresignedUrlDownloadAsync(string path, string fileName);
    }
}
