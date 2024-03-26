using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория работы с пациентами
    /// </summary>
    public interface IPatientRepository
    {
        /// <summary>
        /// Получить постраничный список пациентов
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns> Список курсов</returns>
        Task<List<Domain.Entities.Patient>> GetPagedAsync(int page, int itemsPerPage);

        Task<Domain.Entities.Patient> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Patient patient);
        Task DeleteAsync(Guid id);
        Task<List<Patient>> GetAllAsync();
        Task<bool> ContainsAsync(Guid id);
        Task<bool> UpdateAsync(Patient patient);
    }
}
