using Domain.Entities;
using System;

namespace Services.Contracts
{
    public class DocumentDTO
    {
        /// <summary>
        /// Тип документа
        /// </summary>
        public DocumentTypeEnum DocumentType { get; set; }
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
        public DateTime IssueDate { get; set; }
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
