using gestionAcademica.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Security.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (await context.Users.AnyAsync())
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
                Name = "Administrator",
                FechaRegistro = DateTime.Now,
            };

            context.Users.Add(adminUser);
            await context.SaveChangesAsync();
        }
    }
}
