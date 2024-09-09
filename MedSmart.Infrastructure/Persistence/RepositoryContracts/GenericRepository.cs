using MedSmart.Core.Domain.IRepositoryContracts;
using MedSmart.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MedSmart.Infrastructure.Persistence.RepositoryContracts
{
    /// <include file='Documentation.xml' path='doc/members/member[@name="T:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1"]/*'/>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.#ctor(MedSmart.Infrastructure.Persistence.Data.ApplicationDbContext)"]/*'/>
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.AddAsync(`0)"]/*'/>
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.AddRangeAsync(System.Collections.Generic.IEnumerable{`0})"]/*'/>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.DeleteAsync(`0)"]/*'/>
        public Task DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            return Task.CompletedTask;
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.DeleteRangeAsync(System.Collections.Generic.IEnumerable{`0})"]/*'/>
        public Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
            return Task.CompletedTask;
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.FindAsync(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}})"]/*'/>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.AsNoTracking().Where(predicate).ToListAsync();
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.GetAllAsync"]/*'/>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.GetByIdAsync(System.Int32)"]/*'/>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.SaveChangesAsync"]/*'/>
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.UpdateAsync(`0)"]/*'/>
        public Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            return Task.CompletedTask;
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.GenericRepository`1.GetPagedAsync(System.Int32,System.Int32)"]/*'/>
        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize)
        {
            var totalCount = await _entities.CountAsync();
            var items = await _entities.AsNoTracking()
                                       .Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();
            return (items, totalCount);
        }
    }
}
