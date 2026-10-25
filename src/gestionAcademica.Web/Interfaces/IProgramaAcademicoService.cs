using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Models;

namespace gestionAcademica.Web.Interfaces;

public interface IProgramaAcademicoService
{
    Task<ProgramaAcademicoDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProgramaAcademicoDto>> GetAllAsync();
    Task<ProgramaAcademico> CreateAsync(ProgramaAcademicoDto programaAcademico);
    Task<bool> UpdateAsync(ProgramaAcademicoDto programaAcademico);
    Task<bool> DeleteAsync(Guid id);
}
