using MediatR;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.UseCases.Community.Commands.Follow;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Community.Commands.Unfollow
{

    public class UnfollowCommunityCommandHandler : IRequestHandler<UnfollowCommunityCommand, CommandResponse<Unit>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommunityRepository _communityRepository;

        public UnfollowCommunityCommandHandler(IUserRepository userRepository, ICommunityRepository communityRepository)
        {
            _userRepository = userRepository;
            _communityRepository = communityRepository;
        }

        public virtual async Task<CommandResponse<Unit>> Handle(UnfollowCommunityCommand request, CancellationToken cancellationToken)
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
                await _communityRepository.RemoveFollowerAsync(communityId, userId);
                return CommandResponse<Unit>.Success($"Usuário com id {userId} parou de seguir a comunidade com id {communityId}");
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
