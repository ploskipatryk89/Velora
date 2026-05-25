using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Domain.Abstractions
{
    public interface IUserRepository
    {

        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellationToken = default);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
