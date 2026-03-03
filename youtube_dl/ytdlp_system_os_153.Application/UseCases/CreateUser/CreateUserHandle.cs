using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ytdlp_system_os_153.Domain.Entities;
using ytdlp_system_os_153.Domain.Interfaces;

namespace ytdlp_system_os_153.Application.UseCases.CreateUser
{
    public class CreateUserHandle : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        public CreateUserHandle(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var hash = _passwordHasher.HashPassword(user, request.Password);
            user.SetPasswordHash(hash);

            _userRepository.Add(user);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
