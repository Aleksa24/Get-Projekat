using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Get_Projekat.Data;
using Get_Projekat.Repositories.Ispit;
using Get_Projekat.Repositories.Student;
using Get_Projekat.Services.Ispit;
using Get_Projekat.Services.Student;
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

namespace Get_Projekat
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
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("GetProjekatConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("policy",
                    builder => 
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddMvc();

            services.AddControllers();

            services.AddScoped<IStudentRepository,SqlStudentRepository>();
            services.AddScoped<IIspitReposutory,SqlIspitRepository>();
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<IIspitService,IspitService>();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Get_Projekat", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Get_Projekat v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("policy");

            //app.UseAuthorization();

            app.UseExceptionHandler("/error");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
