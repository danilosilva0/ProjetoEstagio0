﻿using ControleTarefas.Repository.Interface.IRepositories;
using ControleTarefas.Repository.Repositories;
using ControleTarefas.Service.Interface.Services;
using ControleTarefas.Service.Services;
using ControleTarefas.WebApi.Configuration;
using ControleTarefas.WebApi.Middleware;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace ControleTarefas.WebApi
{
    public class Startup
    {
        public Startup()
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDependencyInjectionConfiguration();
            services.AddFluentConfiguration();  
            services.AddTransient<ApiMiddleware>();

            services.AddSwaggerGen(c =>
            {
                c.MapType(typeof(TimeSpan), () => new() { Type = "string", Example = new OpenApiString("00:00:00") });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Controle de Tarefas",
                    Version = "v1",
                    Description = "APIs de estudo",
                    Contact = new() { Name = "Danilo Silva", Url = new Uri("http://google.com.br")},
                    License = new() { Name = "Private", Url = new Uri("http://google.com.br")},
                    TermsOfService = new Uri("http://google.com.br")
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de Tarefas v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseMiddleware<ApiMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
