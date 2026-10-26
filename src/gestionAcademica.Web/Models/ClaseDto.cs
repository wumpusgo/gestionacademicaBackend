using gestionAcademica.Core.Entities;

namespace gestionAcademica.Web.Models;

public class ClaseDto
{
    public Guid Id { get; set; }
    public Guid IdMateria { get; set; }
    public Guid IdProfesor { get; set; }
}
