using System.Collections.Generic;

namespace gestionAcademica.Core.Entities;

public class Profesor
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
