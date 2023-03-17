using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using static CPS_EF.Models.AppDBContext;

namespace CPS_EF.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter, int pageSize, int pageIndex)
        {
            IQueryable<T> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            int totalItem = await query.CountAsync();

            return await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }


        public async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Create(T entity)
        {
            entity.DateCreated = DateTime.Now;
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            entity.DateUpdated = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        Task<IQueryable<T>> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.Get(Expression<Func<T, bool>> filter, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
    }
}