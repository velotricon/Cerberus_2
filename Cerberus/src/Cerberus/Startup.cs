using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Cerberus.Interfaces;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.Models;
using Cerberus.Managers;
using Cerberus.Services;

namespace Cerberus
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string root_path = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>().ContentRootPath;
            services.AddMvc().AddJsonOptions(o => o.SerializerSettings.ContractResolver = new DefaultContractResolver());

            string connection = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=" + root_path + @"\AppData\MainDb.mdf;Initial Catalog=MainDb;"
                + @"Integrated Security=True;Trusted_Connection =True;MultipleActiveResultSets=true";
            //string connection = @"data source=(LocalDB)\MSSQLLocalDB;Database=MainDb.mdf;Initial Catalog=MainDb;"
            //    + @"Integrated Security=True;Trusted_Connection =True;MultipleActiveResultSets=true";
            services.AddDbContext<MainContext>(options => options.UseSqlServer(connection));

            //Managers:
            services.AddScoped<IAddressManager, AddressManager>();
            //services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IBankAccountManager, BankAccountManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IPersonManager, PersonManager>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRoleManager, UserRoleManager>();

            //Services:
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IEncryptionService, EncryptionService>();

            //services.AddIdentity
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseMvc();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            DbInitializer.Initialize(app.ApplicationServices);
        }
    }
}
