using AutoMapper;
using Services.Contracts;
using WebApi.Models;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности курса.
    /// </summary>
    public class PatientMappingsProfile : Profile
    {
        public PatientMappingsProfile()
        {
            CreateMap<PatientDto, PatientModel>();
            CreateMap<PatientModel, PatientDto>();
        }
    }
}
