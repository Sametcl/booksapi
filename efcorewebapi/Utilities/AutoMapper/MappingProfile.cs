using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace efcorewebapi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<BookDtoForUpdate, Book>();
        }
    }
}
