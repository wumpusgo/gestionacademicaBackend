using AutoMapper;
using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Models;

namespace gestionAcademica.Web.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProgramaAcademico, ProgramaAcademicoDto>()
            .ForAllMembers(opt => opt.MapFrom(src => src));

        CreateMap<ProgramaAcademicoDto, ProgramaAcademico>()
            .ForAllMembers(opt => opt.MapFrom(src => src));
    }
}
