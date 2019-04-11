using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HealthOS.Data;
using HealthOS.Models;
using HealthOS.Repositories;
using HealthOS.Repositories.Interfaces;
using HealthOS.Services;

namespace HealthOS
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWeightRepository, WeightRepository>();
            services.AddTransient<IHeightRepository, HeightRepository>();
            services.AddTransient<IGlucoseLevelRepository, GlucoseLevelRepository>();
            services.AddTransient<IBloodPressureRepository, BloodPressureRepository>();
            services.AddTransient<ICustomStatisticsRepository, CustomStatisticsRepository>();
            services.AddTransient<IDrugsRepository, DrugsRepository>();
            services.AddTransient<IDiseaseRepository, DiseaseRepository>();
            services.AddTransient<IAllergyRepository, AllergyRepository>();
            services.AddTransient<IVisitsRepository, VisitsRepository>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
