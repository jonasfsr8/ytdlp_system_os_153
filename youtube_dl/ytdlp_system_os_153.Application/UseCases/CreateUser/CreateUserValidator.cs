using FluentValidation;

namespace ytdlp_system_os_153.Application.UseCases.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(80);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100).EmailAddress();
        }
    }
}
