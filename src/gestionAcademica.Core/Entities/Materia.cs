using System.Collections.Generic;

namespace gestionAcademica.Core.Entities;

public class Materia
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Creditos { get; set; }
    public ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
