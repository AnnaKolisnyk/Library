using AutoMapper;
using lab_5.Models.Entities;
using lab_5.Models.Request;

namespace lab_5.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, ReqBook>().ReverseMap();
        }
    }
}
