using gestionAcademica.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Security.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            try
            {
                if (await context.Users.AnyAsync())
                {
                    return;
                }

                var hasher = new PasswordHasher<ApplicationUser>();

                ApplicationUser[] users =
                [
                    new ApplicationUser
                    {
                        UserName = "Emilio",
                        Email = "Emilio@universidad.com.co",
                        Name = "Emilio Fuentes",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "EmilioPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "Juana",
                        Email = "Juana@universidad.com.co",
                        Name = "Juana Torres",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "JuanaPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "CarlosPerez",
                        Email = "carlosperez@universidad.com.co",
                        Name = "Carlos Perez",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "CarlosPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "MariaGarcia",
                        Email = "mariagarcia@universidad.com.co",
                        Name = "Maria Garcia",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "MariaPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "JoseRodriguez",
                        Email = "joserodriguez@universidad.com.co",
                        Name = "Jose Rodriguez",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "JosePass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "AnaMartinez",
                        Email = "anamartinez@universidad.com.co",
                        Name = "Ana Martinez",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "AnaPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "LuisLopez",
                        Email = "luislopez@universidad.com.co",
                        Name = "Luis Lopez",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "LuisPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "ElenaSanchez",
                        Email = "elenasanchez@universidad.com.co",
                        Name = "Elena Sanchez",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "ElenaPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "DiegoTorres",
                        Email = "dietorres@universidad.com.co",
                        Name = "Diego Torres",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "DiegoPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "SofiaCastro",
                        Email = "sofiacastro@universidad.com.co",
                        Name = "Sofia Castro",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "SofiaPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "MiguelAngel",
                        Email = "miguelangel@universidad.com.co",
                        Name = "Miguel Angel",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "MiguelPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "LauraJimenez",
                        Email = "laurajimenez@universidad.com.co",
                        Name = "Laura Jimenez",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "LauraPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "PedroGomez",
                        Email = "pedrogomez@universidad.com.co",
                        Name = "Pedro Gomez",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "PedroPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "IsabelRuiz",
                        Email = "isabelruiz@universidad.com.co",
                        Name = "Isabel Ruiz",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "IsabelPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "FernandoDiaz",
                        Email = "fernandodiaz@universidad.com.co",
                        Name = "Fernando Diaz",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "FernandoPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "ClaraMorales",
                        Email = "claramorales@universidad.com.co",
                        Name = "Clara Morales",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "ClaraPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "RobertoSilva",
                        Email = "robertosilva@universidad.com.co",
                        Name = "Roberto Silva",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "RobertoPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "LuciaMendez",
                        Email = "luciamendez@universidad.com.co",
                        Name = "Lucia Mendez",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "LuciaPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "HugoHerrera",
                        Email = "hugoherrera@universidad.com.co",
                        Name = "Hugo Herrera",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "HugoPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "PaulaVega",
                        Email = "paulavega@universidad.com.co",
                        Name = "Paula Vega",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "PaulaPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "VictorOrtiz",
                        Email = "victorortiz@universidad.com.co",
                        Name = "Victor Ortiz",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "VictorPass123!",
                    },
                    new ApplicationUser
                    {
                        UserName = "SaraVidal",
                        Email = "saravidal@universidad.com.co",
                        Name = "Sara Vidal",
                        RegisterDate = DateTime.Now,
                        PasswordHash = "SaraPass123!",
                    },
                ];

                for (int i = 0; i < users.Count(); i++)
                {
                    users[i].PasswordHash = hasher.HashPassword(users[i], users[i].PasswordHash!);
                }
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
                Console.WriteLine("Database seeded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database seeding: {ex.Message}");
            }
        }

        // private static string GenerateHash(string password)
        // {
        //     var hasher = new PasswordHasher<ApplicationUser>();
        //     return hasher.HashPassword(new ApplicationUser(), password);
        // }
    }
}
