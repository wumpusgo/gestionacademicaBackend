using gestionAcademica.Security.Models;
using gestionAcademica.Services;
using gestionAcademica.Services.Security;

namespace gestionAcademica.Security.Data
{
    public static class DbInitializer
    {
        public static async Task SeedApplicationDataAsync(
            ApplicationDbContext context,
            SecurityDataService securityDataService,
            ModelDataService modelDataService
        )
        {
            ApplicationUser[] estudiantes =
            {
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Emilio",
                    Email = "Emilio@universidad.com.co",
                    Name = "Emilio Fuentes",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Juana",
                    Email = "Juana@universidad.com.co",
                    Name = "Juana Torres",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "CarlosPerez",
                    Email = "carlosperez@universidad.com.co",
                    Name = "Carlos Perez",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "MariaGarcia",
                    Email = "mariagarcia@universidad.com.co",
                    Name = "Maria Garcia",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "JoseRodriguez",
                    Email = "joserodriguez@universidad.com.co",
                    Name = "Jose Rodriguez",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "AnaMartinez",
                    Email = "anamartinez@universidad.com.co",
                    Name = "Ana Martinez",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "LuisLopez",
                    Email = "luislopez@universidad.com.co",
                    Name = "Luis Lopez",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "ElenaSanchez",
                    Email = "elenasanchez@universidad.com.co",
                    Name = "Elena Sanchez",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "DiegoTorres",
                    Email = "dietorres@universidad.com.co",
                    Name = "Diego Torres",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "SofiaCastro",
                    Email = "sofiacastro@universidad.com.co",
                    Name = "Sofia Castro",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "MiguelAngel",
                    Email = "miguelangel@universidad.com.co",
                    Name = "Miguel Angel",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "LauraJimenez",
                    Email = "laurajimenez@universidad.com.co",
                    Name = "Laura Jimenez",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "PedroGomez",
                    Email = "pedrogomez@universidad.com.co",
                    Name = "Pedro Gomez",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "IsabelRuiz",
                    Email = "isabelruiz@universidad.com.co",
                    Name = "Isabel Ruiz",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "FernandoDiaz",
                    Email = "fernandodiaz@universidad.com.co",
                    Name = "Fernando Diaz",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "ClaraMorales",
                    Email = "claramorales@universidad.com.co",
                    Name = "Clara Morales",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "RobertoSilva",
                    Email = "robertosilva@universidad.com.co",
                    Name = "Roberto Silva",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "LuciaMendez",
                    Email = "luciamendez@universidad.com.co",
                    Name = "Lucia Mendez",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "HugoHerrera",
                    Email = "hugoherrera@universidad.com.co",
                    Name = "Hugo Herrera",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "PaulaVega",
                    Email = "paulavega@universidad.com.co",
                    Name = "Paula Vega",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "VictorOrtiz",
                    Email = "victorortiz@universidad.com.co",
                    Name = "Victor Ortiz",
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "SaraVidal",
                    Email = "saravidal@universidad.com.co",
                    Name = "Sara Vidal",
                },
            };
            await securityDataService.SeedAsync(context, estudiantes);
            var estudiantesList = await modelDataService.SeedEstudiantesAsync(context, estudiantes);
            var profesoresList = await modelDataService.SeedProfesoresAsync(context);
            var materiasList = await modelDataService.SeedMateriasAsync(context);
            await modelDataService.SeedClasesAsync(context, materiasList, profesoresList);
        }
    }
}
