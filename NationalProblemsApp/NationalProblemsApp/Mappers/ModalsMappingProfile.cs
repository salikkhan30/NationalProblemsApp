using AutoMapper;
using NationalProblemsApp.Data;
using NationalProblemsApp.Entities;
using System.Data;

namespace NationalProblemsApp.Mappers
{
    public class ModalsMappingProfile : Profile
    {
        public ModalsMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Feedback, FeedbackDTO>();
            CreateMap<FeedbackDTO, Feedback>();


        }

    }
}