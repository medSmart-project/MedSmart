using CloudinaryDotNet;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;
using MedSmart.Infrastructure.Persistence.Data;
using MedSmart.Infrastructure.Persistence.RepositoryContracts;
using Microsoft.EntityFrameworkCore.Storage;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

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

    public IImageRepository ImageRepository => new ImageRepository(_context, new Cloudinary());

    public IMedicationRepository MedicationRepository => new MedicationRepository(_context, new GenericRepository<Medication>(_context));

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}