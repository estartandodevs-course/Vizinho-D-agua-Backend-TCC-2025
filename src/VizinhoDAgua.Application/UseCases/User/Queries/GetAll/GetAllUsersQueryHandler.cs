using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Cloud.Interfaces;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetAll
{
    public class GetAllUsersQueryHandler 
        : GetAllQueryHandler<UserEntity, GetAllUsersQuery, GetAllUsersQueryResponse>
    {
        private readonly IAwsS3Service _awsS3Service;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper, IAwsS3Service awsS3Service) 
            : base(userRepository, mapper)
        {
            _awsS3Service = awsS3Service;
        }

        public override async Task<CommandResponse<GetAllUsersQueryResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();

            var usersWithProfileImage = users.Select(async user =>
            {
                if (string.IsNullOrEmpty(user.ProfileImage))
                    return user;

                var profileImage = await _awsS3Service.GeneratePresignedUrlDownloadAsync
                (
                    $"users/{user.Id}/{user.ProfileImage}", user.ProfileImage ?? string.Empty
                );

                user.AddProfileImage(profileImage);

                return user;
            });

            var usersWithProfileImageResolved = await Task.WhenAll(usersWithProfileImage);

            var response = _mapper.Map<GetAllUsersQueryResponse>(users);

            return CommandResponse<GetAllUsersQueryResponse>.Success(response, HttpStatusCode.OK);
        }
    }
}
