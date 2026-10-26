using gestionAcademica.Web.Models;
using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Interfaces;

public interface IProfesorService
{
    Task<ProfesorDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProfesorDto>> GetAllAsync();
    Task<Profesor> CreateAsync(ProfesorDto profesorDto);
    Task<bool> UpdateAsync(ProfesorDto profesorDto);
    Task<bool> DeleteAsync(Guid id);
}
