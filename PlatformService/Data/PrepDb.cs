using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        //responsible for starting the data seeding process
        //IApplicationBuilder gives access to applications services..
        //applicationBuilder.ApplicationServices--gives access to di containers
        //CreateScope gives a templorary scope to di--->beacuse dbcontext is a scoped service
        //ServiceProvider.GetRequiredService<AppDbContext>() this gives the serices registered in di --->AppDbContext
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());

            }


        }


        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding data...");

                context.Platforms.AddRange(
                    new Platform
                    {
                        Name = "Docker",
                        Publisher = "Docker",
                        Cost = "Free"
                    },
                    new Platform
                    {
                        Name = "Kubernetes",
                        Publisher = "CNCF",
                        Cost = "Free"
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already persent...");
            }
        }

    }

}