namespace ytdlp_system_os_153.Application.UseCases.CreateUser
{
    public sealed record CreateUserResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
