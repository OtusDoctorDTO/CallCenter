using Domain.Entities;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations.Mapping
{
    public static class Extentions
    {
        public static List<PatientDto> ToPatientsDto(this List<Patient> patients)
        {
            return patients.Select(p=> p.ToPatientDto()).ToList();
        }

        public static PatientDto ToPatientDto(this Patient patient)
        {
            return new PatientDto()
            {

            };
        }
    }
}
