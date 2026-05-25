using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;
using Velora.Domain.Exceptions.Users;

namespace Velora.Application.Features.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.IsAlreadyExistAsync(request.Email, cancellationToken);

            if (userExists)
            {
                throw new UserAlreadyExistsException(request.Email);
            }

            var user = request.Adapt<User>();

            user.PasswordHash = _passwordHasher.HashPassword(request.Password);

            _userRepository.Add(user);

           await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new RegisterResponse(user.Id, user.Email);
        }
    }
}
