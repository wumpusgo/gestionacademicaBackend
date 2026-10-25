using gestionAcademica.Security.Data;
using gestionAcademica.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Services.Security
{
    public class SecurityDataService
    {
        public async Task SeedAsync(ApplicationDbContext context, ApplicationUser[] estudiantes)
        {
            try
            {
                if (await context.Users.AnyAsync())
                {
                    return;
                }

                var hasher = new PasswordHasher<ApplicationUser>();

                List<ApplicationUser> users = new List<ApplicationUser>();
                for (int i = 0; i < estudiantes.Count(); i++)
                {
                    users.Add(
                        new ApplicationUser
                        {
                            UserName = estudiantes[i].UserName,
                            Email = estudiantes[i].Email,
                            Name = estudiantes[i].Name,
                            RegisterDate = DateTime.Now,
                            PasswordHash = $"{estudiantes[i].UserName.ToLower()}Pass123!",
                        }
                    );
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
    }
}
