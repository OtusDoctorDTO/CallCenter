using HelpersDTO.Patient.DTO;
using Services.Abstractions;

using Services.Implementations.Mapping;
using Services.Repositories.Abstractions;
using System;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с пациентами
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IDocumentRepository _patientRepository;

        public PatientService(IDocumentRepository courseRepository)
        {
            _patientRepository = courseRepository;
        }

    }
}