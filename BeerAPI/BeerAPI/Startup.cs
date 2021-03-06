﻿using BeerAPI.Data.Migration;
using BeerAPI.Infra;
using BeerAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;


namespace BeerAPI
{
    public class Startup
    {
        private readonly IHostingEnvironment _Environment;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _Environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsForApplication(_Environment, Configuration);

            services.AddMvc(config =>
            {
                config.ModelBinderProviders.Insert(0, new ArrayStringModelBinder());
                config.ModelBinderProviders.Insert(0, new RangeModelBinder());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "API" });
            });

            var connectionString = Configuration["ConnectionString"];

            services
                .AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddPostgres10_0()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(typeof(Migration_202008031642_Ingredient).Assembly).For.All());

            services.AddNHibernate(connectionString);

            services.Scan(scan =>
                scan.FromAssemblyOf<IIngredientProvider>()
                    .AddClasses()
                    .AsMatchingInterface());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "API");
                c.RoutePrefix = "";
            });
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = ExceptionHandler.Handle
            });

            app.UseMvc();

            app.Migrate();
        }
    }
}
