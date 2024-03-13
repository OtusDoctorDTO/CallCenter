using AutoMapper;
using Domain.Entities;
using Services.Contracts;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности пациента
    /// </summary>
    public class PatientMappingsProfile : Profile
    {
        public PatientMappingsProfile()
        {
            CreateMap<Patient, PatientDto>();
            
            CreateMap<PatientDto, Patient>()
                .ForMember(d => d.Id, map => map.Ignore())
        }
    }
}
