using System;

namespace Domain.Entities
{
    /// <summary>
    /// Модель урока
    /// </summary>
    public class Lesson: IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Тема
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        public virtual Course Course { get; set; }
        
        /// <summary>
        /// Id курса
        /// </summary>
        public int CourseId { get; set; }
        
        /// <summary>
        /// Удалено
        /// </summary>
        public bool Deleted { get; set; }
    }
}