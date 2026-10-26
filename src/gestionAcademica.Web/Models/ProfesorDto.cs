using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Models;

public class ProfesorDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public Profesor Profesor { get; set; } = default!;
}
