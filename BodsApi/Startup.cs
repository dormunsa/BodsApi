using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodsApi.ActionFilters;
using BodsData;
using BodsRuntimeLog.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BodsApi
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors();
            services.AddMvc(options =>
            {
                // subscribe exception action filter to get every exception
                options.Filters.Add(new HandleExceptions());
            });


            //swagger - 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "BODS API",
                    Description = "Each request must contain Client Secret And Client Id",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Dor", Email = "dmun@gmail.com" }
                });

                c.AddSecurityDefinition("ClientId", new ApiKeyScheme()
                {
                    Description = "ClientId",
                    Name = "ClientId",
                    In = "header"
                });

                c.AddSecurityDefinition("ClientSecret", new ApiKeyScheme()
                {
                    Description = "ClientSecret",
                    Name = "ClientSecret",
                    In = "header"
                });

                c.AddSecurityDefinition("UserGuid", new ApiKeyScheme()
                {
                    Description = "UserGuid",
                    Name = "UserGuid",
                    In = "header"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "ClientId", new string[] { } },
                    { "ClientSecret", new string[] { } },
                    { "UserGuid", new string[] { } }
                });


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // initialize db connection string and Client Id and ClientSecret by values that stored in app.json
                InitConnectionString(Configuration["Db:LOCAL"], Configuration["RuntimeLogsDB:LOCAL"]);
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // initialize db connection string and Client Id and ClientSecret by values that stored in app.json
                InitConnectionString(Configuration["Db:PROD"], Configuration["RuntimeLogsDB:PROD"]);
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V2");
            });


            app.UseMvc();
        }

        public void InitConnectionString(string sqlConnection, string sqlRunTimeConnection)
        {
            DataRunTimeLogs.RuntimeLogsConnectionString = sqlRunTimeConnection;
            DataLayer.ConnectionString = sqlConnection;
            AuthorizationActionFilter.ClientId = Configuration["ClientId"];
            AuthorizationActionFilter.ClientSecret = Configuration["ClientSecret"];
        }
    }
}
