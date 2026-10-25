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
                    UserName = "Emilio",
                    Email = "Emilio@universidad.com.co",
                    Name = "Emilio Fuentes",
                },
                new ApplicationUser
                {
                    UserName = "Juana",
                    Email = "Juana@universidad.com.co",
                    Name = "Juana Torres",
                },
                new ApplicationUser
                {
                    UserName = "CarlosPerez",
                    Email = "carlosperez@universidad.com.co",
                    Name = "Carlos Perez",
                },
                new ApplicationUser
                {
                    UserName = "MariaGarcia",
                    Email = "mariagarcia@universidad.com.co",
                    Name = "Maria Garcia",
                },
                new ApplicationUser
                {
                    UserName = "JoseRodriguez",
                    Email = "joserodriguez@universidad.com.co",
                    Name = "Jose Rodriguez",
                },
                new ApplicationUser
                {
                    UserName = "AnaMartinez",
                    Email = "anamartinez@universidad.com.co",
                    Name = "Ana Martinez",
                },
                new ApplicationUser
                {
                    UserName = "LuisLopez",
                    Email = "luislopez@universidad.com.co",
                    Name = "Luis Lopez",
                },
                new ApplicationUser
                {
                    UserName = "ElenaSanchez",
                    Email = "elenasanchez@universidad.com.co",
                    Name = "Elena Sanchez",
                },
                new ApplicationUser
                {
                    UserName = "DiegoTorres",
                    Email = "dietorres@universidad.com.co",
                    Name = "Diego Torres",
                },
                new ApplicationUser
                {
                    UserName = "SofiaCastro",
                    Email = "sofiacastro@universidad.com.co",
                    Name = "Sofia Castro",
                },
                new ApplicationUser
                {
                    UserName = "MiguelAngel",
                    Email = "miguelangel@universidad.com.co",
                    Name = "Miguel Angel",
                },
                new ApplicationUser
                {
                    UserName = "LauraJimenez",
                    Email = "laurajimenez@universidad.com.co",
                    Name = "Laura Jimenez",
                },
                new ApplicationUser
                {
                    UserName = "PedroGomez",
                    Email = "pedrogomez@universidad.com.co",
                    Name = "Pedro Gomez",
                },
                new ApplicationUser
                {
                    UserName = "IsabelRuiz",
                    Email = "isabelruiz@universidad.com.co",
                    Name = "Isabel Ruiz",
                },
                new ApplicationUser
                {
                    UserName = "FernandoDiaz",
                    Email = "fernandodiaz@universidad.com.co",
                    Name = "Fernando Diaz",
                },
                new ApplicationUser
                {
                    UserName = "ClaraMorales",
                    Email = "claramorales@universidad.com.co",
                    Name = "Clara Morales",
                },
                new ApplicationUser
                {
                    UserName = "RobertoSilva",
                    Email = "robertosilva@universidad.com.co",
                    Name = "Roberto Silva",
                },
                new ApplicationUser
                {
                    UserName = "LuciaMendez",
                    Email = "luciamendez@universidad.com.co",
                    Name = "Lucia Mendez",
                },
                new ApplicationUser
                {
                    UserName = "HugoHerrera",
                    Email = "hugoherrera@universidad.com.co",
                    Name = "Hugo Herrera",
                },
                new ApplicationUser
                {
                    UserName = "PaulaVega",
                    Email = "paulavega@universidad.com.co",
                    Name = "Paula Vega",
                },
                new ApplicationUser
                {
                    UserName = "VictorOrtiz",
                    Email = "victorortiz@universidad.com.co",
                    Name = "Victor Ortiz",
                },
                new ApplicationUser
                {
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
