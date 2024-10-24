using RepositoryPattern.Core.IRepositories;

namespace RepositoryPattern.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        
        Task CompleteAsync();
    }
}
