using gestionAcademica.Web.Models;
using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Interfaces;

public interface IClaseService
{
    Task<ClaseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ClaseDto>> GetAllAsync();
    Task<Clase> CreateAsync(ClaseDto claseDto);
    Task<bool> UpdateAsync(ClaseDto claseDto);
    Task<bool> DeleteAsync(Guid id);
}
