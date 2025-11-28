using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.User.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadProfileImageCommandHandler
        : UpdateCommandHandlerWithReturn<UserEntity, GeneratePresignedForUploadProfileImageCommand, GeneratePresignedForUploadProfileImageCommandResponse>
    {
        private readonly IAwsS3Service _awsS3Service;
        protected override GeneratePresignedForUploadProfileImageCommandResponse response { get; set; } = null!;

        public GeneratePresignedForUploadProfileImageCommandHandler(IUserRepository userRepository, IMapper mapper, IAwsS3Service awsS3Service)
            : base(userRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GeneratePresignedForUploadProfileImageCommandResponse>> Handle(GeneratePresignedForUploadProfileImageCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<GeneratePresignedForUploadProfileImageCommandResponse>.ValidationError(request.ValidationResult);

            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
                return CommandResponse<GeneratePresignedForUploadProfileImageCommandResponse>
                    .AddError(message: "Usuário não encontrado.", statusCode: HttpStatusCode.NotFound);

            if (request.FileName == user.ProfileImage)
                return CommandResponse<GeneratePresignedForUploadProfileImageCommandResponse>
                    .AddError(message: "O nome do arquivo não pode ser igual ao da imagem atual do usuário.", statusCode: HttpStatusCode.Conflict);

            var filePathInS3 = $"users/{user.Id}/{request.FileName}";

            var presignedUrl = await GeneratePresignedUrlForUpload(filePathInS3, request.FileName);

            user.AddProfileImage(request.FileName);
            await _repository.UpdateAsync(user);

            response = new GeneratePresignedForUploadProfileImageCommandResponse(presignedUrl);

            return CommandResponse<GeneratePresignedForUploadProfileImageCommandResponse>
                .Success(response, HttpStatusCode.OK);
        }

        private async Task<string> GeneratePresignedUrlForUpload(string filePathInS3, string fileName)
        {
            var presignedUrl = await _awsS3Service.GeneratePresignedUrlUploadAsync(filePathInS3, fileName);
            return presignedUrl;
        }


    }
}
