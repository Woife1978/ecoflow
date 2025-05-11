using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

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
            // Load the connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("EcoflowDatabase");

            // Register the DbContext with the connection string
            builder.Services.AddDbContext<EcoflowPostgreDbContext>(options => 
                options.UseNpgsql(connectionString));
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
            //app.UseDefaultFiles(); // Serve index.html by default
            //app.UseStaticFiles(); // Serve static files from wwwroot

            // Serve React static files from /react-frontend/build
            app.UseDefaultFiles(new DefaultFilesOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "react-frontend", "build")),
                RequestPath = ""
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "react-frontend", "build")),
                RequestPath = ""
            });

            // Map API controllers
            app.MapControllers();

            // Fallback to React for unmatched routes
           // Exclude Swagger from fallback
            app.MapWhen(context => !context.Request.Path.StartsWithSegments("/swagger"), subApp =>
            {
                subApp.UseRouting();
                subApp.UseEndpoints(endpoints =>
                {
                    app.MapFallbackToFile("index.html", new StaticFileOptions
                    {
                        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "react-frontend", "build"))
                    });
                });
            });

            app.Run();
        }
    }
}