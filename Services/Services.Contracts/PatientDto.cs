using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Services.Contracts
{
    /// <summary>
    /// ДТО пациента
    /// </summary>
    public class PatientDto
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Данные документа
        /// </summary>
        public DocumentDTO Document { get; set; }
        public List<ContactDTO> Contacts { get; set; }
        /// <summary>
        /// Статус пациента
        /// </summary>
        public RelevanceStatusEnum Status { get; set; } = RelevanceStatusEnum.New;
    }
}