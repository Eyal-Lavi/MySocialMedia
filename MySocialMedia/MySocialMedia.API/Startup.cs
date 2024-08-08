using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using MySocialMedia.API.Middlwares;
using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.Helpers;
using MySocialMedia.Logic;
using MySocialMedia.Logic.Extensions;
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
                option.UseMySql(Properties.Resources.StringConnectionDB, new MySqlServerVersion(new Version(8, 0, 37)));
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddJwtAuthenticaion(Configuration);
            services.AddWebSockets(options =>
            {
                options.KeepAliveInterval = TimeSpan.FromSeconds(120); // שמירת פתיחה  כל 120
            });
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

            app.UseAuthentication(); // הוספת אימות
            
            app.UseAuthorization();

            app.UseWebSockets();

            app.UseMiddleware<WebSocketMiddlewareInjector>();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
