using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVersoning.Controllers;

namespace WebApiVersoning
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiVersoning", Version = "V1" });
            });
            services.AddApiVersioning(options=> {
                options.AssumeDefaultVersionWhenUnspecified = true;
                //  options.DefaultApiVersion = new ApiVersion(1, 1); // This will be equalent to version 1.1
                options.DefaultApiVersion = ApiVersion.Default;
                //options.ApiVersionReader = new MediaTypeApiVersionReader("version"); // 1- Passing version info with accept header
                //options.ApiVersionReader = new HeaderApiVersionReader("X-Version"); // 2- Passing version info as Api header

                options.ApiVersionReader = ApiVersionReader.Combine(
                    new MediaTypeApiVersionReader("version"),
                    new HeaderApiVersionReader("X-Version")
                    ); // Combined Passing version info with accept header and Api Header

                //options.Conventions.Controller<UsersController>()
                //.HasDeprecatedApiVersion(1, 0)
                //.HasApiVersion(2, 0)
                //.Action(typeof(UsersController).GetMethod(nameof(UsersController.GetV2))!)
                //.MapToApiVersion(2,0);

                options.ReportApiVersions = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiVersoning v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
