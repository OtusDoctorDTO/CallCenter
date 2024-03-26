using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с курсами
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private readonly DatabaseContext context;

        public PatientRepository(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Получить всех пациентов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Patient>> GetAllAsync()
        {
            var status = (int)RelevanceStatusEnum.Deleted;
            return await context.Patients.Where(x => x.Status != status).ToListAsync();
        }

        /// <summary>
        /// Получить постраничный список пациентов
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns> Список курсов</returns>
        public async Task<List<Patient>> GetPagedAsync(int page, int itemsPerPage)
        {
            var patients = await GetAllAsync();
            return patients
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }

        /// <summary>
        /// Добавить пациента
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(Patient patient)
        {
            await context.AddAsync(patient);
            await context.SaveChangesAsync();
            return patient.Id;
        }


        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await context.Patients
                .Include(x => x.Contacts)
                .Include(x => x.Document)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<bool> ContainsAsync(Guid id)
        {
            return await context.Patients.AnyAsync(x => x.Id == id);
        }
        public async Task<bool> UpdateAsync(Patient patient)
        {
            if (await ContainsAsync(patient.Id))
            {
                var patientBD = await GetByIdAsync(patient.Id);
                patientBD.Status = patient.Status;
                patientBD.DocumentId = patient.DocumentId;
                patientBD.Document = patient.Document;
                patientBD.Contacts = patient.Contacts;
                await context.SaveChangesAsync();
                return true;
            }
            throw new NotImplementedException($"Не удалось обновить данные. Пациента с id - {patient.Id} не существует");
        }
    }
}
