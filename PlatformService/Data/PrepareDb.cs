using PlatformService.Models;

namespace PlatformService.Data
{
    public class PrepareDb
    {
        public static void PropPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("---> Seeding Our data");
                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "free" },
                    new Platform() { Name = "Kubernetes", Publisher = "cloud Native Computing Foundation", Cost = "free" }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--->we already have data");
            }
        }
    }
}
