using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CPS_EF.Repository
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        TContext Context { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
