using Microsoft.AspNetCore.Http;
using System.Security.Claims;

using Velora.Domain.Abstractions;

namespace Velora.Infrastructure.Auth
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid GetCurrentUser()
        {
            var userId = _contextAccessor.HttpContext?
                .User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                throw new Exception("Brak autoryzacji");
            }

            return Guid.Parse(userId);
        }
    }
}
