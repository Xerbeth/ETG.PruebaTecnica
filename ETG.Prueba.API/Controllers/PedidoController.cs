#region Referencias
using ETG.Prueba.Core.DTOs;
using ETG.Prueba.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion Referencias

namespace ETG.Prueba.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        #region Propiedades
        #region Dependencias
        private readonly IPedidoServices _pedidoServices;
        #endregion Dependencias
        #endregion Propiedades

        #region Métodos 
        #region Constructor
        public PedidoController(IPedidoServices pedidoServices)
        {
            this._pedidoServices = pedidoServices;
        }
        #endregion Constructor        

        /// <summary>
        /// Método para registrar un pedido
        /// </summary>
        /// <param name="pedido"> Objeto con los datos del pedido </param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(PedidoDTO pedido)
        {
            var createOrder = await _pedidoServices.CreateOrder(pedido);
            return Ok(createOrder);
        }

        /// <summary>
        /// Método para actualizar un registro de pedido
        /// </summary>        
        /// <param name="pedido"> Objeto de datos para actualizar </param>
        /// <returns> Resultado de la transacción </returns>
        //[Authorize]
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(PedidoDTO pedido)
        {
            var updateOrder = await _pedidoServices.UpdateOrder(pedido);            
            return Ok(updateOrder);
        }

        /// <summary>
        /// Método para realizar el borrado físico de un registro de pedido   
        /// </summary>
        /// <param name="idPedido"> Identificador del pedido </param>
        /// <returns> Resultado de la transacción </returns>
        //[Authorize]
        [HttpDelete("DeleteOrder/{idPedido}")]
        public async Task<IActionResult> DeleteOrder(int idPedido)
        {
            var deleteOrder = await _pedidoServices.DeleteOrder(idPedido);
            return Ok(deleteOrder);
        }        

        /// <summary>
        /// Método para consultar todos los registros de los productos
        /// </summary>
        /// <returns>Lista con la información de los productos </returns>
        //[Authorize]
        [HttpGet("GetAllOrderes")]
        public async Task<IActionResult>GetAllOrderes()
        {
            var getAllOrderes = await _pedidoServices.GetAllOrderes();            
            return Ok(getAllOrderes);
        }

        /// <summary>
        /// Método para consultar la información de un usuario por su identificador
        /// </summary>
        /// <param name="idPedido"> Identificador del pedido </param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("GetOrderById/{idProducto}")]
        public async Task<IActionResult> GetOrderById(int idPedido)
        {
            var getOrderById = await _pedidoServices.GetOrderById(idPedido);
            return Ok(getOrderById);
        }
        #endregion Métodos

    }
}
