using gestionAcademica.Core.Entities;
using gestionAcademica.Security.Data;
using gestionAcademica.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Services
{
    public class ModelDataService
    {
        public async Task<List<Estudiante>> SeedEstudiantesAsync(
            ApplicationDbContext context,
            ApplicationUser[] estudiantes
        )
        {
            try
            {
                if (await context.Estudiiantes.AnyAsync())
                {
                    return await context.Estudiiantes.ToListAsync();
                }

                var hasher = new PasswordHasher<ApplicationUser>();

                List<Estudiante> users = new List<Estudiante>();

                foreach (var estudiante in estudiantes)
                {
                    users.Add(new Estudiante { Id = Guid.NewGuid(), Nombre = estudiante.Name });
                }
                await context.Estudiiantes.AddRangeAsync(users);
                await context.SaveChangesAsync();
                Console.WriteLine("Database seeded successfully.");
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database seeding: {ex.Message}");
                return new List<Estudiante>();
            }
        }

        public async Task<List<Profesor>> SeedProfesoresAsync(ApplicationDbContext context)
        {
            try
            {
                if (await context.Profesores.AnyAsync())
                {
                    return await context.Profesores.ToListAsync();
                }

                List<Profesor> profesores = new List<Profesor>
                {
                    new Profesor { Id = Guid.NewGuid(), Nombre = "Profesor 1" },
                    new Profesor { Id = Guid.NewGuid(), Nombre = "Profesor 2" },
                    new Profesor { Id = Guid.NewGuid(), Nombre = "Profesor 3" },
                    new Profesor { Id = Guid.NewGuid(), Nombre = "Profesor 4" },
                    new Profesor { Id = Guid.NewGuid(), Nombre = "Profesor 5" },
                };

                await context.Profesores.AddRangeAsync(profesores);
                await context.SaveChangesAsync();
                Console.WriteLine("Database seeded successfully for Profesores.");
                return profesores;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database seeding for Profesores: {ex.Message}");
                return new List<Profesor>();
            }
        }

        public async Task<List<Materia>> SeedMateriasAsync(ApplicationDbContext context)
        {
            try
            {
                if (await context.Materias.AnyAsync())
                {
                    return await context.Materias.ToListAsync();
                }

                List<Materia> materias = new List<Materia>
                {
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Matemáticas",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Física",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Química",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Programación I",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Programación II",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Cálculo Diferencial",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Cálculo Integral",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Álgebra Lineal",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Estructuras de Datos",
                        Creditos = 3,
                    },
                    new Materia
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Bases de Datos",
                        Creditos = 3,
                    },
                };

                await context.Materias.AddRangeAsync(materias);
                await context.SaveChangesAsync();
                Console.WriteLine("Database seeded successfully for Materias.");
                return materias;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database seeding for Materias: {ex.Message}");
                return new List<Materia>();
            }
        }

        public async Task SeedClasesAsync(
            ApplicationDbContext context,
            List<Materia> materias,
            List<Profesor> profesores
        )
        {
            try
            {
                if (await context.Clases.AnyAsync())
                {
                    return;
                }

                List<Clase> clases = new List<Clase>();

                for (int i = 0; i < profesores.Count; i++)
                {
                    var profesor = profesores[i];
                    for (int j = 0; j < 2; j++)
                    {
                        var materia = materias.First();
                        materias.Remove(materia);
                        clases.Add(
                            new Clase
                            {
                                Id = Guid.NewGuid(),
                                IdMateria = materia.Id,
                                IdProfesor = profesor.Id,
                                Materia = materia,
                                Profesor = profesor,
                            }
                        );
                    }
                }

                await context.Clases.AddRangeAsync(clases);
                await context.SaveChangesAsync();
                Console.WriteLine("Database seeded successfully for Clases.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database seeding for Clases: {ex.Message}");
            }
        }
    }
}
