using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CadastroDeVendas.Models;
using CadastroDeVendas.Data;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,SeedingService seeding)//chamei aqui no parametro a classe SeedingService
        {
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
