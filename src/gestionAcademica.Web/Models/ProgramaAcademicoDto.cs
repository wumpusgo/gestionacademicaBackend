using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Models;

public class ProgramaAcademicoDto
{
    public Guid Id { get; set; }
    public Guid IdClase { get; set; }
    public Guid IdEstudiante { get; set; }
    public Clase Clase { get; set; } = default!;
    public Estudiante Estudiante { get; set; } = default!;
}
