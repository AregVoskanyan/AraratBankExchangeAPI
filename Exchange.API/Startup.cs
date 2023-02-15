using Exchange.API.Data;
using Exchange.API.Helpers.Enums;
using Exchange.API.Services;
using Exchange.API.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Exchange.API
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
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:ConnectionString"].ToString());
            });

            services.AddHttpClient(ExternalRestServices.RateService.ToString(), c =>
            {
                c.BaseAddress = new Uri(Configuration["ExternalRestServices:RateService:BaseUrl"]);
                c.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(Configuration["ExternalRestServices:RateService:Timeout"]));
                c.DefaultRequestHeaders.Add(Configuration["ExternalRestServices:RateService:Authorization:Key"],
                    Configuration["ExternalRestServices:RateService:Authorization:Value"]);
            });

            services.AddSingleton<IRateService, RateService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exchange.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exchange.API v1"));
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
