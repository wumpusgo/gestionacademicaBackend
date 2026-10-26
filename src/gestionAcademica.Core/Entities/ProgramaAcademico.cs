namespace gestionAcademica.Core.Entities;

public class ProgramaAcademico
{
    public Guid Id { get; set; }
    public Guid IdClase { get; set; }
    public Guid IdEstudiante { get; set; }

    // public Clase? Clase { get; set; }
    // public Estudiante? Estudiante { get; set; }
}
