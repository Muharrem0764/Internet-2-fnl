using AutoMapper;
using vize.API.Dtos;
using vize.API.Models;
using vize.Dtos;
using vize.Models;

namespace vize.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
