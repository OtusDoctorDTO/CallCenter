using System;

namespace Domain.Entities
{
    /// <summary>
    /// Документ удостоверяющий личность
    /// </summary>
    public class Document
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }
        /// <summary>
        /// Тип документа
        /// </summary>
        public int? DocumentType { get; set; }
        /// <summary>
        /// Серия
        /// </summary>
        public string Series { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime? IssueDate { get; set; }
        /// <summary>
        /// Кем выдано
        /// </summary>
        public string IssuedBy { get; set; }
        /// <summary>
        /// Код подразделения
        /// </summary>
        public string DepartmentCode { get; set; }
    }
}
