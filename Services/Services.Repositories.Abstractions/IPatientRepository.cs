using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория работы с пациентами
    /// </summary>
    public interface IPatientRepository: IRepository<Domain.Entities.Patient, Guid>
    {
        /// <summary>
        /// Получить постраничный список пациентов
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns> Список курсов</returns>
        Task<List<Domain.Entities.Patient>> GetPagedAsync(int page, int itemsPerPage);
    }
}
