using System;
using System.Threading.Tasks;

namespace Enterprise.Repository
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();
    }

    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task CommitAsync();
        //Task RollbackAsync();
        //Task<int> SaveChangesAsync();
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class, new();
    }

    public interface IUowFactory
    {
        IUnitOfWorkAsync Start(IRepositoryContextAsync context);
        IUnitOfWorkAsync Start<T>() where T : class;
    }
}
