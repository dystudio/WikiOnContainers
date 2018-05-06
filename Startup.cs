using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Aiursoft.Wiki.Data;
using Aiursoft.Wiki.Models;
using Aiursoft.Pylon;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpOverrides;
using Aiursoft.Wiki.Services;
using Aiursoft.Pylon.Services;
using Aiursoft.Pylon.Services.ToAPIServer;
using Aiursoft.Pylon.Models;
using Aiursoft.Pylon.Services.ToOSSServer;
using Aiursoft.Pylon.Middlewares;
using Aiursoft.Pylon.Models.API.OAuthAddressModels;

namespace Aiursoft.Wiki
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WikiDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DatabaseConnection")));

            services.AddMvc();

            services.AddSingleton<AppsContainer>();
            //services.AddSingleton<ServiceLocation>();
            services.AddScoped<HTTPService>();
            services.AddScoped<UrlConverter>();
            services.AddScoped<OSSApiService>();
            services.AddScoped<StorageService>();
            services.AddScoped<CoreApiService>();
            services.AddScoped<OAuthService>();
            services.AddTransient<Seeder>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseEnforceHttps();
                app.UseExceptionHandler("/Error/ServerException");
                app.UseStatusCodePagesWithReExecute("/Error/Code{0}");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseLanguageSwitcher();
            app.UseMvcWithDefaultRoute();
        }
    }
}
