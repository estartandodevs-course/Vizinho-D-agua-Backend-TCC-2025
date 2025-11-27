using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Infrastructure.Cloud
{
    public class AwsS3Service : IAwsS3Service
    {
        private readonly IAmazonS3 _s3Client;

        public AwsS3Service()
        {
            var accessKey = Environment.GetEnvironmentVariable("AWS_S3_ACCESS_KEY");
            var secretKey = Environment.GetEnvironmentVariable("AWS_S3_SECRET_KEY");
            var region = Environment.GetEnvironmentVariable("AWS_S3_REGION");

            _s3Client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.GetBySystemName(region));
        }

        public async Task<string> GeneratePresignedUrlUploadAsync(string path, string fileName)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = Environment.GetEnvironmentVariable("AWS_S3_BUCKET_NAME"),
                Key = $"{path}/{fileName}",
                Expires = DateTime.UtcNow.AddMinutes(15),
                Verb = HttpVerb.PUT
            };

            var respone = await _s3Client.GetPreSignedURLAsync(request);

            return respone;
        }

        public async Task<string> GeneratePresignedUrlDownloadAsync(string path, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;

            var request = new GetPreSignedUrlRequest
            {
                BucketName = Environment.GetEnvironmentVariable("AWS_S3_BUCKET_NAME"),
                Key = $"{path}/{fileName}",
                Expires = DateTime.UtcNow.AddMinutes(15),
                Verb = HttpVerb.GET
            };

            var response = await _s3Client.GetPreSignedURLAsync(request);

            return response;
        }
    }
}
