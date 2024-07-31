using Microsoft.EntityFrameworkCore;
using MySocialMedia.Common.Helpers;
using MySocialMedia.Logic;
using MySocialMedia.Logic.Services;

namespace MySocialMedia.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MySocialMediaDBContext>(option =>
            {
                option.UseMySql(Configuration.GetConnectionString("defaultconnection"), new MySqlServerVersion(new Version(8, 0, 37)));
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
