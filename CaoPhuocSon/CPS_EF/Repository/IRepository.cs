using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static CPS_EF.Models.AppDBContext;

namespace CPS_EF.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAll();
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter, int pageSize, int pageIndex);
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}