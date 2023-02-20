using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionExchange.Api.Data;
using TransactionExchange.Api.Data.Entities;
using TransactionExchange.Api.Enums;
using TransactionExchange.Api.Middlewares;
using TransactionExchange.Api.Services;
using TransactionExchange.Api.Services.Interfaces;
using static TransactionExchange.Api.Middlewares.RequestResponseLoggingMiddleware;

namespace TransactionExchange.Api
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
            services.AddDbContext<ApplicationDataContext>(options =>
            {
                options.UseSqlServer(Configuration["DatabaseConnections:TransactionExchangeDb"].ToString());
            });

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"])),

                ValidateIssuer = true,
                ValidIssuer = Configuration["JWT:Issuer"],

                ValidateAudience = true,
                ValidAudience = Configuration["JWT:Audience"],

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDataContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = tokenValidationParameters;
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TransactionExchange.Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert the token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "Jwt",
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { 
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TransactionExchange.Api v1"));
            }

            app.UseHttpsRedirection();

            //Action<RequestProfilerModel> requestResponseHandler = requestProfilerModel =>
            //{
            //    LoggerUtility.WriteRequestLog(requestProfilerModel, DBConnections.AppLog);
            //};
            //app.UseMiddleware<RequestResponseLoggingMiddleware>(requestResponseHandler);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppDbInitializer.SeedRolesToDb(app).Wait();
        }
    }
}
