using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Models;

public class MateriaDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Creditos { get; set; }
    public Materia Materia { get; set; } = default!;
}
