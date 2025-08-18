using AutoMapper;
using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Application.DTOs.Patients;
using Clinic.Api.Application.DTOs.Questions;
using Clinic.Api.Application.DTOs.Users;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserContext, UserDto>().ReverseMap();
            CreateMap<LoginUserDto, UserContext>();
            CreateMap<CreateAppointmentDto, AppointmentsContext>().ReverseMap();
            CreateMap<SavePatientDto, PatientsContext>().ReverseMap();
            CreateMap<SaveTreatmentsDto, TreatmentsContext>().ReverseMap();
            CreateMap<SaveQuestionValueDto, QuestionValuesContext>().ReverseMap();
        }
    }
}
