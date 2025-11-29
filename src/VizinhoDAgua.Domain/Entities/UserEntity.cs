using VizinhoDAgua.Domain.Entities.Abstractions;

namespace VizinhoDAgua.Domain.Entities
{
    public class UserEntity : Entity
    { 
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool IsAdmin { get; private set; }
        public string? ProfileImage { get; private set; }

        // EF Core
        public List<CommunityEntity> Communities { get; private set; } = [];
        public List<CommunityEntity> CommunitiesFollowed { get; private set; } = [];
        public List<EducationContentEntity> EducationContents { get; private set; } = [];
        public List<CommunityPostEntity> Posts { get; private set; } = [];
        public List<ReportEntity> Reports { get; private set; } = [];
        
        public UserEntity() {  } // EF Core

        public UserEntity(string name, string email, string password, string? profileImage)
        {
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = false;
            ProfileImage = profileImage;
        }

        public void AddProfileImage(string profileImage)
        {
            ProfileImage = profileImage;
        }
    }
}