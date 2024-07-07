using AutoMapper;
using Task2.UpSkilling.Dtos;
using Task2.UpSkilling.Models;

namespace Task2.UpSkilling.MappingProfile
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tasks, TasksDto>().ReverseMap();
            CreateMap<TeamMember, TeamMemberDto>().ReverseMap();

        }
    }
}
