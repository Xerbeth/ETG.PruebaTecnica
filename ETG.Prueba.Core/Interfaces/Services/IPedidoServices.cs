#region Referencias
using ETG.Prueba.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.Interfaces.Services
{
    public interface IPedidoServices
    {
        Task<ApiResponse<bool>> CreateOrder(PedidoDTO pedido);
        Task<ApiResponse<bool>> UpdateOrder(PedidoDTO pedido);
        Task<ApiResponse<bool>> DeleteOrder(int idPedido);
        Task<ApiResponse<List<PedidoDTO>>> GetAllOrderes();
        Task<ApiResponse<PedidoDTO>> GetOrderById(int idPedido);
    }
}
