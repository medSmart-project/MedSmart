﻿using System.Linq.Expressions;

namespace MedSmart.Core.Domain.IRepositoryContracts;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
   
    Task<IEnumerable<T?>> GetAllAsync();
    Task<IEnumerable<T?>> FindAsync(Expression<Func<T, bool>>? predicate);
  
   
    Task AddAsync(T? entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T? entity);
    Task DeleteRangeAsync(IEnumerable<T?> entities);
    
    Task<int> SaveChangesAsync();



}