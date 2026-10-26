using gestionAcademica.Web.Models;
using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Interfaces;

public interface IEstudianteService
{
    Task<EstudianteDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<EstudianteDto>> GetAllAsync();
    Task<Estudiante> CreateAsync(EstudianteDto estudianteDto);
    Task<bool> UpdateAsync(EstudianteDto estudianteDto);
    Task<bool> DeleteAsync(Guid id);
}
