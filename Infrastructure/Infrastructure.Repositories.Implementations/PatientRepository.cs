using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с курсами
    /// </summary>
    public class PatientRepository: Repository<Patient, Guid>, IPatientRepository 
    {
        public PatientRepository(DatabaseContext context): base(context)
        {
        }
      
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns> Список курсов</returns>
        public async Task<List<Patient>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
    }
}
