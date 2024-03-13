using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts;

namespace Services.Abstractions
{
    /// <summary>
    /// Сервис работы с уроками (интерфейс)
    /// </summary>
    public interface ILessonService
    {
        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns></returns>
        Task<ICollection<LessonDto>> GetPaged(int page, int pageSize);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО урока</returns>
        Task<LessonDto> GetById(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="lessonDto">ДТО урока</param>
        /// <returns>идентификатор</returns>
        Task<Guid> Create(LessonDto advertisementDto);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="lessonDto">ДТО урока</param>
        Task Update(Guid id, LessonDto advertisementDto);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        Task Delete(Guid id);
    }
}