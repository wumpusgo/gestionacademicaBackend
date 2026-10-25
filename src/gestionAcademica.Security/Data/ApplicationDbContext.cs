using gestionAcademica.Core.Entities;
using gestionAcademica.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Security.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Estudiante> Estudiiantes { get; set; }
        public DbSet<ProgramaAcademico> ProgramasAcademicos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profesor>().HasKey(p => p.Id);

            modelBuilder.Entity<Materia>().HasKey(m => m.Id);

            modelBuilder.Entity<Clase>().HasKey(c => c.Id);

            modelBuilder
                .Entity<Clase>()
                .HasOne(c => c.Profesor)
                .WithMany(p => p.Clases)
                .HasForeignKey(c => c.IdProfesor);

            modelBuilder
                .Entity<Clase>()
                .HasOne(c => c.Materia)
                .WithMany(m => m.Clases)
                .HasForeignKey(c => c.IdMateria);

            modelBuilder.Entity<ProgramaAcademico>().HasKey(pa => pa.Id);

            modelBuilder
                .Entity<ProgramaAcademico>()
                .HasOne(pa => pa.Clase)
                .WithMany(c => c.ProgramasAcademicos)
                .HasForeignKey(pa => pa.IdClase);

            modelBuilder
                .Entity<ProgramaAcademico>()
                .HasOne(pa => pa.Estudiante)
                .WithMany()
                .HasForeignKey(pa => pa.IdEstudiante);
        }
    }
}
