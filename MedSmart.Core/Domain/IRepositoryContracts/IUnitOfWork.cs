namespace MedSmart.Core.Domain.IRepositoryContracts;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync();
    IMedicationRepository MedicationRepository { get; }

}