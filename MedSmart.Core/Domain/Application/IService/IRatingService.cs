using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSmart.Core.Domain.Application.IService
{
    public interface IRatingService
    {
        Task AddAsync(Rating rating);
        Task UpdateAsync(int userId, Rating rate);
        Task DeleteAsync(int userId);
        Task<Rating?> GetByIdAsync(int userId);
    }
}
