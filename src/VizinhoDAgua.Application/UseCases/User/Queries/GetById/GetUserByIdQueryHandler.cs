using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetById
{
    public class GetUserByIdQueryHandler 
        : GetByIdQueryHandler<UserEntity, GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        private readonly IAwsS3Service _awsS3Service;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper, IAwsS3Service awsS3Service) 
            : base(userRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GetUserByIdQueryResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
                return CommandResponse<GetUserByIdQueryResponse>.AddError(message: "Usuário não encontrado.", statusCode: HttpStatusCode.NotFound);

            if(!string.IsNullOrEmpty(user.ProfileImage))
            {
                var profileImage = await _awsS3Service.GeneratePresignedUrlDownloadAsync(
                    $"users/{user.Id}/{user.ProfileImage}",
                    user.ProfileImage ?? string.Empty);

                user.AddProfileImage(profileImage);
            }

            var response = _mapper.Map<GetUserByIdQueryResponse>(user);

            return CommandResponse<GetUserByIdQueryResponse>.Success(response, HttpStatusCode.OK);
        }
    }
}
