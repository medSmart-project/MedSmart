using Microsoft.EntityFrameworkCore.Storage;

namespace MedSmart.Core.Domain.IRepositoryContracts;

public interface IUnitOfWork : IDisposable
{


    IGenericRepository<T> Repository<T>() where T : class;
    IImageRepository ImageRepository { get; }
    IMedicationRepository MedicationRepository { get; }
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task<int> SaveChangesAsync();

}