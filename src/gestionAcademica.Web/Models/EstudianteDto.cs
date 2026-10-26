using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Models;

public class EstudianteDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public Estudiante Estudiante { get; set; } = default!;
}
