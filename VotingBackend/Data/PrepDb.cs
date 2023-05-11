using Microsoft.EntityFrameworkCore;
using VotingBackend.Models;

namespace VotingBackend.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
            }
        }


        private static void SeedData(AppDbContext context, bool isProduction)
        {
            if (isProduction)
            {
                Console.WriteLine("--> Applying migrations");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Couldn't run migrations: {ex}");
                }
            }

            if (context.SupportUsers.Any())
            {
                Console.WriteLine("--> Not Adding Data.");
                return;
            }

            Console.WriteLine("--> Adding Data.");
            context.SupportUsers.Add(
                new SupportUser()
                {
                    Identification = "119350628",
                    Name = "Daniel Ricardo",
                    LastName = "Sequeira Campos",
                    Password = "Seque1505!"
                }
            );

            context.SaveChanges();
            return;
        }
    }
}