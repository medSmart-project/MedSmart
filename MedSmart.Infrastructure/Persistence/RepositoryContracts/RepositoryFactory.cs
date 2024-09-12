using System.Net.Mime;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;
using MedSmart.Infrastructure.Persistence.Data;
using MedSmart.Infrastructure.Persistence.RepositoryContracts;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly ApplicationDbContext _context;

    public RepositoryFactory(ApplicationDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<T> CreateRepository<T>() where T : class
    {
        return new GenericRepository<T>(_context);
    }

    public IMedicationRepository CreateMedicationRepository()
    {
        return new MedicationRepository(_context, new GenericRepository<Medication>(_context));
    }

    public IImageRepository CreateImageRepository()
    {
        return new ImageRepository(_context, new CloudinaryDotNet.Cloudinary());
    }
}