using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EcoflowFrontend{
  public class Program
    {
        public static void LoadConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        static void Main(string[] args)
        {
            LoadConfiguration();            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddDbContext<EcoflowPostgreDbContext>();

            // Add Swagger services
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ecoflow API",
                    Version = "v1",
                    Description = "API documentation for EcoflowFrontend"
                });
            });
            var app = builder.Build();
    
            // Enable Swagger middleware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecoflow API v1");
                c.RoutePrefix = "swagger"; // Serve Swagger UI at the root
            });
            
            // Serve React static files
            app.UseDefaultFiles(); // Serve index.html by default
            app.UseStaticFiles(); // Serve static files from wwwroot

            // Map API controllers
            app.MapControllers();

            // Fallback to React for unmatched routes
           // Exclude Swagger from fallback
            app.MapWhen(context => !context.Request.Path.StartsWithSegments("/swagger"), subApp =>
            {
                subApp.UseRouting();
                subApp.UseEndpoints(endpoints =>
                {
                    app.MapFallbackToFile("react/index.html");
                });
            });

            app.Run();
        }
    }
}