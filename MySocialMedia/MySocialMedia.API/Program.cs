using Microsoft.AspNetCore.Hosting;

namespace MySocialMedia.API
{
    public class Program
    {
        private const string URL = "httpS://localhost:7121";
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(URL);
                });
    }
}
