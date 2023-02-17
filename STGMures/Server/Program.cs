global using StgMures.Shared;
global using StgMures.Shared.DbModels;
global using StgMures.Shared.Dto;

global using StgMures.Server.Data;
global using StgMures.Server.Services;



namespace StgMures.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseIISIntegration()
                    .UseIIS()
                    .UseKestrel().UseStartup<Startup>();
                    
                });
    }
}


