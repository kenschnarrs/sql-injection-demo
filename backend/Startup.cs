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
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            services.AddScoped<DbContext, MyDbContext>();

            services.AddDbContext<MyDbContext>(
                options => 
                    options.UseMySql(Configuration.GetConnectionString("MySqlConnection"), serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            services.AddControllers();
        }

        public static void ConfigureEntityFramework(IServiceCollection services)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            services.AddDbContextPool<MyDbContext>(
                options => options.UseMySql("server=localhost;user=root;database=sys;port=3306;password=my_password2", serverVersion));
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
