using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Models;

namespace gestionAcademica.Web.Interfaces;

public interface IProgramaAcademicoService
{
    Task<ProgramaAcademicoDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProgramaAcademicoDto>> GetAllAsync();
    Task<IEnumerable<ProgramaAcademicoDto>> GetByEstudianteIdAsync(Guid estudianteId);
    Task<ProgramaAcademico> CreateAsync(ProgramaAcademicoDto programaAcademico);
    Task<bool> UpdateAsync(ProgramaAcademicoDto programaAcademico);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> CreateNewProgram(Guid idEstudiante, List<ProgramaAcademicoDto> programasAcademicos);
    Task<IEnumerable<ClaseDto>> GetClasesByEstudianteIdAsync(Guid estudianteId);
    Task<IEnumerable<ClaseDto>> GetAvailableClasesByEstudianteIdAsync(Guid estudianteId);
}
