using Services.Abstractions;
using Services.Contracts;
using Services.Implementations.Mapping;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с пациентами
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _pacientRepository;

        public PatientService(IPatientRepository courseRepository)
        {
            _pacientRepository = courseRepository;
        }

        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns></returns>
        public async Task<ICollection<PatientDto>> GetPaged(int page, int pageSize)
        {
            var result = await _pacientRepository.GetPagedAsync(page, pageSize);
            return result.ToPatientsDto();
        }

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО пациента</returns>
        public async Task<PatientDto> GetById(Guid id)
        {
            var patient = await _pacientRepository.GetByIdAsync(id);
            return patient.ToPatientDto();
        }

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="patientDto">ДТО пациента</param>
        /// <returns>идентификатор</returns>
        public async Task<Guid> Create(PatientDto patientDto)
        {
            var patient = patientDto.ToPatient();
            return await _pacientRepository.AddAsync(patient);
        }

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="patientDto">ДТО пациента</param>
        public async Task Update(Guid id, PatientDto patientDto)
        {
            var patient = patientDto.ToPatient();
            patient.Id = id;
            await _pacientRepository.UpdateAsync(patient);
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        public async Task DeleteAsync(Guid id)
        {
            await _pacientRepository.DeleteAsync(id);
        }
    }
}