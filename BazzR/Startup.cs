using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BasicAuthentication.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bazzr
{
    public static class DBConfiguration
	{
        public static string ConnectionString = "Server=localhost;Port=8889;database=bazzr;uid=root;pwd=root;";
	}
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            env.EnvironmentName = "Development";
            var builder = new ConfigurationBuilder() 
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; set; }
		public void ConfigureServices(IServiceCollection services)
		{

            services.AddEntityFrameworkMySql()
              .AddDbContext<ApplicationDbContext>(options => 
                                                  options.
                                                  UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();


			services.AddMvc();
            // This is new:   
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireDigit = false;
            });
}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
			app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
