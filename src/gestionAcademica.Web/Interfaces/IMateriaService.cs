using gestionAcademica.Web.Models;
using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Interfaces;

public interface IMateriaService
{
    Task<MateriaDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<MateriaDto>> GetAllAsync();
    Task<Materia> CreateAsync(MateriaDto materiaDto);
    Task<bool> UpdateAsync(MateriaDto materiaDto);
    Task<bool> DeleteAsync(Guid id);
}
