using StudentApi.Models;
using AutoMapper;
namespace StudentApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PutDto, Student>();
            CreateMap<Student, PutDto>();
            CreateMap<Student,PostDto>();
            CreateMap<PostDto, Student>();

        }
    }
}
