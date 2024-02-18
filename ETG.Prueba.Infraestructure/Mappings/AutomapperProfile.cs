#region Referencias
using AutoMapper;
using ETG.Prueba.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Infraestructure.Mappings
{
    /// <summary>
    /// Clase para la definición de los objetos de mapeo
    /// </summary>
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Core.Entities.Usuarios, UsuariosDTO>().ReverseMap();
            CreateMap<Core.Entities.Producto, ProductoDTO>().ReverseMap();
            CreateMap<Core.Entities.Pedido, PedidoDTO>().ReverseMap();
        }
    }
}
