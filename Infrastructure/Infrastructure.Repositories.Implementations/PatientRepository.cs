using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
            return await context.Patients.ToListAsync();
        }

        /// <summary>
        /// Получить постраничный список пациентов
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns> Список курсов</returns>
        public async Task<List<Patient>> GetPagedAsync(int page, int itemsPerPage)
        {
            return await context.Patients
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
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

        public async Task DeleteAsync(Guid id)
        {
            if (await ContainsAsync(id))
            {
                var patient = await GetByIdAsync(id);
                context.Remove(patient);
                await context.SaveChangesAsync();
                return;
            }
            throw new NotImplementedException($"Не удалось удалить. Пациента с id - {id} не существует");
        }


        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await context.Patients
                .Include(x=> x.Contacts)
                .Include(x=> x.Document)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<bool> ContainsAsync(Guid id)
        {
            return await context.Patients.AnyAsync(x=> x.Id == id);
        }
        public async Task<bool> UpdateAsync(Patient patient)
        {
            if(await ContainsAsync(patient.Id))
            {
                var patientBD = await GetByIdAsync(patient.Id);
                patientBD.Status = patient.Status;
                patientBD.DocumentId = patient.DocumentId;
                await context.SaveChangesAsync();
                return true;
            }
            throw new NotImplementedException($"Не удалось обновить данные. Пациента с id - {patient.Id} не существует");
        }
    }
}
