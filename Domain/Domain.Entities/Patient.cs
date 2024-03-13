using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Пациент, который обратился в клинику, его данные завел сотрудник
    /// </summary>
    public class Patient : IEntity<Guid>
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Данные документа
        /// </summary>
        public Document Document { get; set; }
        public List<Contact> Contacts { get; set; }
        /// <summary>
        /// Статус пациента
        /// </summary>
        public int Status { get; set; }
    }
}
