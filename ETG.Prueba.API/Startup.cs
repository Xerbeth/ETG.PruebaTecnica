#region Referencias
using ETG.Prueba.Application.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ETG.Prueba.Infraestructure.Extensions;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;
using ETG.Prueba.Application.Options;
#endregion Referencias

namespace ETG.Prueba.API
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
            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //para evitar errores por referencias circulares
            services.AddControllers(opc =>
            {
                opc.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            
            services.AddOptions(Configuration);
            services.AddDBContext(Configuration);
            services.AddServices();
            services.AddSwagger(Configuration, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");            

            #region Agregando el filtro de modelo v�lido de forma global
            services.AddMvc(opc =>
            {
                opc.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(opc => {
                opc.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
            #endregion Agregando el filtro de modelo v�lido de forma global            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ETG_Prueba API V1");
                options.RoutePrefix = String.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
