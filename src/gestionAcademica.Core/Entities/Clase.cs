using System.Collections.Generic;

namespace gestionAcademica.Core.Entities;

public class Clase
{
    public Guid Id { get; set; }
    public Guid IdMateria { get; set; }
    public Guid IdProfesor { get; set; }

    public Materia Materia { get; set; } = default!;
    public Profesor Profesor { get; set; } = default!;
    public ICollection<ProgramaAcademico> ProgramasAcademicos { get; set; } = new List<ProgramaAcademico>();
}
