using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ytdlp_system_os_153.Application.Services.Users.Interfaces;
using ytdlp_system_os_153.Application.Services.Users.Requests;
using ytdlp_system_os_153.Application.Services.Users.Responses;
using ytdlp_system_os_153.Domain.Entities;
using ytdlp_system_os_153.Domain.Interfaces;

namespace ytdlp_system_os_153.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(
            IUserRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordHasher<User> passwordHasher)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserResponse> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var hash = _passwordHasher.HashPassword(user, request.Password);

            user.SetPasswordHash(hash, request.Password);

            _repository.Add(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(id, cancellationToken);

            return user == null ? null : _mapper.Map<UserResponse>(user);
        }

        public async Task<IEnumerable<UserResponse>> ListAsync(CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task<UserResponse> UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(request.Id, cancellationToken);

            if (user == null)
                return null;

            user.Name = request.Name;
            user.Email = request.Email;

            _repository.Update(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(id, cancellationToken);

            if (user == null)
                return null;

            _repository.Delete(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UserResponse>(user);
        }
    }
}
