using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAppCore.Interface;
using CarAppCore.Profiles;
using CarAppCore.ServiceCore.BodyTypeService;
using CarAppCore.ServiceCore.BrandService;
using CarAppCore.ServiceCore.Cars;
using CarAppCore.ServiceCore.DriveTypeService;
using CarAppCore.ServiceCore.EngineTypeService;
using CarAppCore.ServiceCore.ModelOfCarService;
using CarAppCore.ServiceCore.TransmissionTypeService;
using CarAppInfrastructure.Context;
using CarAppInfrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CarAppInternship
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

            //domain
            services.AddScoped<ICarService, ÑarService>();
            services.AddScoped<IBodyTypeService,BodyTypeService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IDriveTypeService, DriveTypeService>();
            services.AddScoped<IEngineTypeService, EngineTypeService>();
            services.AddScoped<IModelOfCarService, ModelOfCarService>();
            services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();

            //infrastructure
            services.AddScoped<ICarRepository, CarEFRepository>();
            services.AddScoped<IBodyTypeRepository, BodyTypeEFRepository>();
            services.AddScoped<IBrantRepository, BrandEFRepository>();
            services.AddScoped<IDriveTypeRepository, DriveTypeEFRepository>();
            services.AddScoped<IEngineTypeRepository, EngineTypeEFRepository>();
            services.AddScoped<IModelOfCarRepository, ModelOfCarEFRepository>();
            services.AddScoped<ITransmissionTypeRepository, TransmissionTypeEFRepository>();

            //automapping
            services.AddAutoMapper(
                typeof(CarProfile),
                typeof(BodyTypeProfile),
                typeof(BrandProfile),
                typeof(DriveTypeProfile),
                typeof(EngineTypeProfile),
                typeof(ModelOfCarProfile),
                typeof(TransmissionTypeProfile)
                );


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarAppInternship", Version = "v1" });
            });
            services.AddDbContext<CarAppContext>(context => context.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarAppInternship v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
