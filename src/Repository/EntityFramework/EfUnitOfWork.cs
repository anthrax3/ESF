using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Enterprise.Repository.EntityFramework
{
    public class EfUnitOfWork :  IUnitOfWorkAsync
    {
        private  IRepositoryContextAsync _context;
        private readonly EfContext _efContext;
      
        private Dictionary<string, dynamic> _repositories;
        private IDbContextTransaction _transaction;
        private bool _disposed;

        public EfUnitOfWork(EfContext context)
        {
            _context = context;
            _efContext = _context as EfContext;
        }


        #region Overrides of IUnitOfWork


        public  void BeginTransaction()
        {
           _transaction =  _efContext.DbContext.Database.BeginTransaction();
        }


        public  void Commit()
        {
            if (_transaction != null)
                _transaction.Commit();
            else
                _context.SaveChanges();
        }


        public  void Rollback()
        {
            _transaction.Rollback();
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return GetRepositoryAsync<T>();
        }

        #endregion

        public Task CommitAsync()
        {
            if (_transaction != null)
                return new TaskFactory().StartNew(() => _transaction.Commit());
            else
                return _context.SaveChangesAsync();
        }

        public IRepositoryAsync<T> GetRepositoryAsync<T>() where T : class, new()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof (T).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IRepositoryAsync<T>) _repositories[type];
            }

            var repositoryType = typeof (Repository<>);

            var instance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof (T)), _context);
            (instance as Repository<T>).UoW = this;
            _repositories.Add(type, instance);

            return _repositories[type];
        }



        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            if (_disposed)
                return;
          
                _repositories?.Clear();
                _transaction?.Dispose();

                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            
            _disposed = true;
        }

        #endregion
    }

    public class UowFactory : IUowFactory
    {
        #region Implementation of IUowFactory

        public IUnitOfWorkAsync Start(IRepositoryContextAsync context)
        {
            var efContext = context as EfContext;
            if (efContext == null)
                throw new InvalidCastException("context must be EfContext");
            return new EfUnitOfWork(efContext);
        }

        public IUnitOfWorkAsync Start<T>() where T : class
        {
            if (!typeof(T).GetTypeInfo().IsSubclassOf(typeof(DbContext)))
                throw new InvalidCastException("T must be type of DbContext");
            return new EfUnitOfWork(new EfContext(Activator.CreateInstance<T>() as DbContext));
        }

        #endregion
    }
}