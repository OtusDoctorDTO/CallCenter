using Services.Contracts;
using System;

namespace WebApi.Models
{
    /// <summary>
    /// Модель пациента
    /// </summary>
    public class SavePatientDTORequest: ServiceRequest
    {
        public PatientDto Patient { get; set; }
    }

    public class SavePatientDTOResponse: ServiceResponse
    {
        public Guid Id { get; set; }
    }

    public class ServiceResponse
    {
        public Guid Guid { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string ConnectionId { get; set; }
    }


    /// <summary>
    /// Базовый класс запроса данных
    /// </summary>
    public class ServiceRequest
    {
        //
        // Summary:
        //     guid
        public Guid Guid { get; set; }

        //
        // Summary:
        //     ConnectionId
        public string ConnectionId { get; set; }
    }
}