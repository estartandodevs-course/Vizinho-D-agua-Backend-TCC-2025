namespace VizinhoDAgua.Application.Dtos
{
    public class GeneratePresignedUrlDto
    {
        public string FileName { get; private set; }

        public GeneratePresignedUrlDto(string fileName)
        {
            FileName = fileName;
        }
    }
}
