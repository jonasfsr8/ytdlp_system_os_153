namespace ytdlp_system_os_153.Application.Services.Users.Requests
{
    public class UpdateUserRequest
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
    }
}
