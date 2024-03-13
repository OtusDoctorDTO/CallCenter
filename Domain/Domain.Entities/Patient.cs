﻿using System;
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
        /// Статус пациента
        /// </summary>
        public int Status { get; set; }
        public Guid DocumentId { get; set; }

        /// <summary>
        /// Данные документа
        /// </summary>
        public virtual Document Document { get; set; }
        /// <summary>
        /// Контакты
        /// </summary>
        public virtual List<Contact> Contacts { get; set; }

    }
}
