using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Aiursoft.Pylon;
using Aiursoft.Wiki.Data;
using Aiursoft.Wiki.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Aiursoft.Wiki
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<WikiDbContext>((context, services) =>
                {
                    var seeder = services.GetService<Seeder>();
                    seeder.Seed().Wait();
                })
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>()
                 .Build();

            return host;
        }
    }
}
