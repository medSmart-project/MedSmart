using MedSmart.Core.Domain.IRepositoryContracts;
using MedSmart.Infrastructure.Persistence.Data;

namespace MedSmart.Infrastructure.Persistence.RepositoryContracts
{
    /// <include file='Documentation.xml' path='doc/members/member[@name="T:MedSmart.Infrastructure.Persistence.RepositoryContracts.RepositoryFactory"]/*'/>
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ApplicationDbContext _context;

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.RepositoryFactory.#ctor(MedSmart.Infrastructure.Persistence.Data.ApplicationDbContext)"]/*'/>
        public RepositoryFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <include file='Documentation.xml' path='doc/members/member[@name="M:MedSmart.Infrastructure.Persistence.RepositoryContracts.RepositoryFactory.CreateRepository``1"]/*'/>
        public IGenericRepository<T> CreateRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }
    }
}