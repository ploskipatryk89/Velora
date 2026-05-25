using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Infrastructure.Context;

namespace Velora.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VeloraDbContext _context;

        public UnitOfWork(VeloraDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           await _context.SaveChangesAsync(cancellationToken);
        }

        
    }
}
