using AutoMapper;
using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Models;

namespace gestionAcademica.Web.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProgramaAcademico, ProgramaAcademicoDto>();

        CreateMap<ProgramaAcademicoDto, ProgramaAcademico>();

        CreateMap<Clase, ClaseDto>();

        CreateMap<ClaseDto, Clase>();

        CreateMap<Estudiante, EstudianteDto>();

        CreateMap<EstudianteDto, Estudiante>();

        CreateMap<Materia, MateriaDto>();

        CreateMap<MateriaDto, Materia>();

        CreateMap<Profesor, ProfesorDto>();

        CreateMap<ProfesorDto, Profesor>();
    }
}
