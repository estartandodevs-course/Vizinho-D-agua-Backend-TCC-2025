using MediatR;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Community.Commands.Follow
{
    public class FollowCommunityCommandHandler : IRequestHandler<FollowCommunityCommand, CommandResponse<Unit>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommunityRepository _communityRepository;

        public FollowCommunityCommandHandler(IUserRepository userRepository, ICommunityRepository communityRepository)
        {
            _userRepository = userRepository;
            _communityRepository = communityRepository;
        }

        public async Task<CommandResponse<Unit>> Handle(FollowCommunityCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var communityId = request.CommunityId;

            bool userExists = await _userRepository.Exists(userId);
            if (!userExists)
                return CommandResponse<Unit>.AddError("Usuário com Id fornecido não existe");

            bool communityExists = await _communityRepository.Exists(communityId);
            if (!communityExists)
                return CommandResponse<Unit>.AddError("Comunidade com Id fornecido não existe");

            try
            {
                await _communityRepository.AddFollowerAsync(communityId, userId);
                return CommandResponse<Unit>.Success($"Usuário com id {userId} começou a segui a comunidade com id {communityId}");
            }
            catch (Exception ex)
            {
                return CommandResponse<Unit>.CriticalError(
                    $"Ocorreu um erro ao estabelecer o relacionamento: {ex.Message}"
                );
            }
        }
    }
}
