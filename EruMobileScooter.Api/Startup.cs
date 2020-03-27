using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EruMobileScooter.Data;
using Microsoft.EntityFrameworkCore;
using EruMobileScooter.Service;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using EruMobileScooter.Localization;
using EruMobileScooter.Localization.Models;
using System;

namespace EruMobileScooter.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(o => o.ResourcesPath = "Resources");

            services.AddControllers();

            services.AddDbContext<ApplicationContext>(options => {
                options.UseNpgsql(Configuration.GetConnectionString("postgresConString"));
                //.UseSnakeCaseNamingConvention();
            });
                        
            services.AddScoped<ApplicationContext>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddSingleton<Translator>();
            services.AddSingleton<ILanguage, Language>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            var supportedCultures = new[] { new CultureInfo("en-UK"), new CultureInfo("tr-TR"), };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-UK"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

           app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
