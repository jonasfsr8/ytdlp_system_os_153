namespace ytdlp_system_os_153.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; private set; }

        public User() { }

        public User(string name, string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(name) && name.Length < 2)
                throw new ArgumentException("Invalid name");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email");

            Name = name.Trim();
            Email = email.Trim().ToLowerInvariant();
            PasswordHash = passwordHash;
        }

        public void SetPasswordHash(string passwordHash, string pass)
        {
            if (string.IsNullOrWhiteSpace(pass))
                throw new ArgumentException("Password hash cannot be empty");

            PasswordHash = passwordHash;
        }
    }
}
