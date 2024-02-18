#region Referencias
using ETG.Prueba.Application.Services;
using ETG.Prueba.Core.Interfaces;
using ETG.Prueba.Core.Interfaces.Repository;
using ETG.Prueba.Core.Interfaces.Services;
using ETG.Prueba.Infraestructure.Data;
using ETG.Prueba.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Infraestructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDBContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ETG_DBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ETG_DB")));            
        }

        public static void AddOptions(this IServiceCollection services, IConfiguration Configuration) { }

        public static void AddServices(this IServiceCollection services)
        {
            // Se agregran los servicios  los cuales la capa de infraestructura implementa
            services.AddTransient<IUsuariosServices, UsuariosServices>();
            services.AddTransient<IProductoServices, ProductoServices>();
            services.AddTransient<IPedidoServices, PedidoServices>();
            
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();            
        }

        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration Configuration) { }


        public static void AddSwagger(this IServiceCollection services, IConfiguration Configuration, string xmlFileName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ETG_Prueba API", Version = "v1" });

            });
        }
    }
}
