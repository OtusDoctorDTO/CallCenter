using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Документ удостоверяющий личность
    /// </summary>
    public class Document
    {
        public Guid Id { get; set; }
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
