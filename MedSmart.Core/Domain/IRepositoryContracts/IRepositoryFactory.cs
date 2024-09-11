namespace MedSmart.Core.Domain.IRepositoryContracts;

public interface IRepositoryFactory
{
    IGenericRepository<T> CreateRepository<T>() where T : class;
    IMedicationRepository CreateMedicationRepository();

}