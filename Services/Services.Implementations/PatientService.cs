using Domain.Entities;
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

        public PatientService(
            IPatientRepository courseRepository)
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
            var entities = await _pacientRepository.GetPagedAsync(page, pageSize);
            return entities.ToPatientsDto();
        }

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО пациента</returns>
        public async Task<PatientDto> GetById(Guid id)
        {
            var patient = await _pacientRepository.GetAsync(id);
            return patient.ToPatientDto();
        }

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="patientDto">ДТО пациента</param>
        /// <returns>идентификатор</returns>
        public async Task<Guid> Create(PatientDto patientDto)
        {
            var entity = patientDto.ToPatient();
            var res = await _pacientRepository.AddAsync(entity);
            await _pacientRepository.SaveChangesAsync();
            return res.Id;
        }

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="patientDto">ДТО пациента</param>
        public async Task Update(Guid id, PatientDto patientDto)
        {
            var entity = patientDto.ToPatient();
            entity.Id = id;
            _pacientRepository.Update(entity);
            await _pacientRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        public async Task Delete(Guid id)
        {
            var pacient = await _pacientRepository.GetAsync(id);
            pacient.Status = (int)RelevanceStatusEnum.Deleted; 
            await _pacientRepository.SaveChangesAsync();
        }
    }
}