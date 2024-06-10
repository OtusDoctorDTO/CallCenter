using HelpersDTO.Patient.DTO;
using System;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    /// <summary>
    /// Cервис работы администрации (интерфейс)
    /// </summary>
    public interface IPatientService
    {
        /// <summary>
        /// Сохранение пасспорта при заключении договора новым пациентом
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passport"></param>
        /// <returns></returns>
        Task<Guid> CreatePassport(Guid? userId, PassportDTO passport);
    }
}