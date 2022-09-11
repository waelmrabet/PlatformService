using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder appBuilder)
        {


            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Start of Seeding data)");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
                     new Platform() { Name = "SqlServer Express", Publisher = "Microsoft", Cost = "Free" },
                      new Platform() { Name = "Kebernetes", Publisher = "Cloud computing foundation", Cost = "Free" }
                    );

                context.SaveChanges();

                Console.WriteLine("End of Seeding data)");

            }
            else
            {
                Console.WriteLine("---> Database already populated");
            }

        }

    }
}
