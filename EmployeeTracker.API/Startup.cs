using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTracker.Core.Entities;
using EmployeeTracker.Domain.Commands.User;
using EmployeeTracker.Infrastructure;
using EmployeeTracker.Infrastructure.Abstractions.Services;
using EmployeeTracker.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EmployeeTracker
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeTracker.API", Version = "v1" });
            });
            services
                .AddDbContext<EmployeeTrackerDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("MSSQL")))
                .AddIdentity<User, Role>().AddEntityFrameworkStores<EmployeeTrackerDbContext>();

            services.Scan(scan =>
                scan.FromAssemblyOf<IScopedService>().FromAssemblyOf<AuthenticationService>().AddClasses(classes => classes.AssignableTo<IScopedService>())
                    .AsImplementedInterfaces().WithScopedLifetime());
            services.AddMediatR(typeof(Startup),typeof(LoginCommand));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeTracker.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}