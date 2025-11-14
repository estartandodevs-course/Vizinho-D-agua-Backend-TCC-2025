namespace VizinhoDAgua.Domain.Entities
{
    public class User : Entity
    { 
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool IsAdmin { get; private set; }
        public string ProfileImage { get; private set; } = string.Empty;
        
        public List<Community> Communities { get; private set; } = [];
        public List<CommunityPost> Posts { get; private set; } = [];
        public List<Report> Reports { get; private set; } = [];
        
        public User() {  } // EF Core

        public User(string name, string email, string password, string? profileImage)
        {
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = false;
            ProfileImage = profileImage ?? string.Empty;
        }
        
        public void Update(string name, string email, string? profileImage)
        {
            Name = name;
            Email = email;
            ProfileImage = profileImage ?? string.Empty;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}