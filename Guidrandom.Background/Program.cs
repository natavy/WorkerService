using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RandomGuid.Web.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RandomGuid.Web.Services;
using DNTScheduler.Core;

namespace Guidrandom.Background
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            CreateDatabaseIfNotExist(host);

            host.Run();
        }

        private static void CreateDatabaseIfNotExist(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<GuidDbContext>();
                    context.Database.EnsureCreated();
                  
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    //AppSettings.Configuration = configuration;
                    //AppSettings.ConnectionString = configuration.GetConnectionString("DefaultConn");

                    //var optionBuilder = new DbContextOptionsBuilder<GuidDbContext>();
                    //optionBuilder.UseSqlServer(AppSettings.ConnectionString);
                    services.AddDbContext<GuidDbContext>(options =>
                    {
                        string connectionString = configuration.GetConnectionString("DefaultConn");
                        options.UseSqlServer(connectionString);
                    });

                   // services.AddScoped<GuidDbContext>(d => new GuidDbContext(optionBuilder.Options));
                    services.AddHostedService<Worker>();
                  
                });
    }
}
