using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MusalaSoft.GatewayApp.Api.Core;
using MusalaSoft.GatewayApp.Api.Core.IRepositories;
using MusalaSoft.GatewayApp.Api.Infrastracture.Repositories;
using MusalaSoft.GatewayApp.Api.Infrastracture.Shared;
using MusalaSoft.GatewayApp.Api.Mapper;
using MusalaSoft.GatewayApp.Api.Middleware;

namespace MusalaSoft.GatewayApp.Api
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
            services.AddDbContext<ApplicationDbContext>(opts =>
           opts.UseSqlServer(Configuration.GetConnectionString("DefaultCon")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDeviceRepository, DeviceRepository>( );
            services.AddScoped<IGatewayRepository, GatewayRepository>( );
            #region AutoMapper
            services.AddAutoMapper(typeof(Startup));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DeviceProfile());
                mc.AddProfile(new GatewayProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion
            services.AddControllers();
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusalaSoft Gateway V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseCors(options =>
            {
                options
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials();
            });

            app.UseHttpsRedirection();
            var localizeOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizeOptions.Value);

            app.UseRouting();
            app.UseSwagger();
            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
