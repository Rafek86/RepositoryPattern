﻿using RepositoryPattern.Core.IConfiguration;
using RepositoryPattern.Core.IRepositories;
using RepositoryPattern.Core.Repository;

namespace RepositoryPattern.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly AppDbContext _context;
        private readonly ILogger _logger;


        public IUserRepository Users { get; private set; }

        public UnitOfWork(
            AppDbContext context,
            ILoggerFactory loggerFactory
            ) {
            _context =  context;
            _logger = loggerFactory.CreateLogger("logs");
             Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
          _context.Dispose();
        }
    }
}
