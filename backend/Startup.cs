using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.EntityFrameworkCore.Extensions;
using backend.Data;
using backend.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            /*
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            //services.AddSingleton(MyDbContext);
            services.AddDbContext<IMyDbContext, MyDbContext>(
                options => 
                    options.UseMySql(Configuration.GetConnectionString("MySqlConnection"), serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
            
            services.AddScoped<IMyDbContext, MyDbContext>();
*/
            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
