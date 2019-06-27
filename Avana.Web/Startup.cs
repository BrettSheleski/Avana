using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avana.DataAccess.Core;
using FVTC.LearningInnovations.App;
using FVTC.LearningInnovations.App.Web.MvcCore;
using FVTC.LearningInnovations.DataAccess;
using FVTC.LearningInnovations.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avana.Web
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

            SqliteConnectionStringBuilder connectionBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = "mydb.db"
            };

            services.AddEntityFrameworkSqlite().AddDbContext<Avana.DataAccess.Core.MyDbContext>(options => options.UseSqlite(connectionBuilder.ConnectionString));

            DbContextOptionsBuilder<MyDbContext> optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();

            optionsBuilder.UseSqlite(connectionBuilder.ConnectionString);

            using (var dbContext = new MyDbContext(optionsBuilder.Options))
            {
                dbContext.Database.EnsureCreated();
            }

            services.AddScoped<DbContext, MyDbContext>();
            services.AddScoped<IDataAccessService, FVTC.LearningInnovations.DataAccess.EntityFrameworkCore.DataAccessService>();
            services.AddSingleton<IFactory, FVTC.LearningInnovations.Factory.ActivatorFactory>();

            services.RegisterModelServices(typeof(Avana.Services.DeviceInfoService).Assembly);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "DeviceConfigurationSettings",
                   template: "{filename}settings.txt",
                   defaults: new { controller = "DeviceConfiguration", action = "Settings" }
                   );

                routes.MapRoute(
                   name: "DeviceConfigurationUpgrade",
                   template: "{filename}upgrade.txt",
                   defaults: new { controller = "DeviceConfiguration", action = "Upgrade" }
                   );

                routes.MapRoute(
                   name: "DeviceSpecificUpgrade",
                   template: "upgrade/{model4}/{model}/{mac}/{group}",
                   defaults: new { controller = "DeviceConfiguration", action = "DeviceUpgrade" }
                   );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );

                routes.MapRoute(
                       name: "areas",
                       template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                     );


            });

        }
    }
}
