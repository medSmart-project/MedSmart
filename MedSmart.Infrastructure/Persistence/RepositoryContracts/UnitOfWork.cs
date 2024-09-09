using MedSmart.Core.Domain.IRepositoryContracts;
using MedSmart.Infrastructure.Persistence.Data;

namespace MedSmart.Infrastructure.Persistence.RepositoryContracts
{
    /// <include file='Documentation.xml' path='doc/members/member[@name="T:MedSmart.Infrastructure.Persistence.RepositoryContracts.UnitOfWork"]/*'/>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.UnitOfWork.#ctor(MedSmart.Infrastructure.Persistence.Data.ApplicationDbContext)"]/*'/>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.UnitOfWork.Repository``1"]/*'/>
        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)_repositories[typeof(T)];
            }

            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.UnitOfWork.SaveChangesAsync"]/*'/>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.UnitOfWork.Dispose"]/*'/>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}