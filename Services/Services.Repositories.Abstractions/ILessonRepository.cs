using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория работы с уроками
    /// </summary>
    public interface ILessonRepository: IRepository<Lesson, Guid>
    {
        Task<List<Lesson>> GetPagedAsync(int page, int itemsPerPage);
    }
}
