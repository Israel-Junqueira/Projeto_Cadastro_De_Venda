using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CadastroDeVendas.Models;
using CadastroDeVendas.Data;
using CadastroDeVendas.Services;
using System.Globalization;//para localização
using Microsoft.AspNetCore.Localization; //para localização
using System.Collections.Generic;

namespace CadastroDeVendas
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<CadastroDeVendasContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("CadastroDeVendasContext"), builder =>
                    builder.MigrationsAssembly("CadastroDeVendas")));

            services.AddScoped<SeedingService>(); // adicionei para injetar o addServices. //gestão de dependencia
            services.AddScoped<SellerServiceClass>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<SalesRecordService>(); //adicionado a nova dependencia do Serviços sales Record Service
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,SeedingService seeding)//chamei aqui no parametro a classe SeedingService
        {
            var enUS = new CultureInfo("en-US"); // adicionei para colocar a localização
            var localizationOption = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },     // adicionei para colocar a localização
                SupportedUICultures = new List<CultureInfo> { enUS }
            };
            app.UseRequestLocalization(localizationOption); // adicionei para colocar a localização



            if (env.IsDevelopment()) //se eu estou no perfil de desenvolvimento
            {
                app.UseDeveloperExceptionPage();
                seeding.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); //se estiver no de produção (executando)
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
