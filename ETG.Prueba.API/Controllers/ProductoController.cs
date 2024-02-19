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
    public class ProductoController : ControllerBase
    {
        #region Propiedades
        #region Dependencias
        private readonly IProductoServices _productoServices;
        #endregion Dependencias
        #endregion Propiedades

        #region Métodos 
        #region Constructor
        public ProductoController(IProductoServices productoServices)
        {
            this._productoServices = productoServices;
        }
        #endregion Constructor        

        /// <summary>
        /// Método para registrar un producto
        /// </summary>
        /// <param name="producto"> Objeto con los datos del producto </param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductoDTO producto)
        {
            var createProduct = await _productoServices.CreateProduct(producto);
            return Ok(createProduct);
        }

        /// <summary>
        /// Método para actualizar un registro de producto
        /// </summary>        
        /// <param name="producto"> Objeto de datos para actualizar </param>
        /// <returns> Resultado de la transacción </returns>
        //[Authorize]
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductoDTO producto)
        {
            var updateProduct = await _productoServices.UpdateProduct(producto);            
            return Ok(updateProduct);
        }

        /// <summary>
        /// Método para realizar el borrado físico de un registro de producto   
        /// </summary>
        /// <param name="idProducto"> Identificador del producto </param>
        /// <returns> Resultado de la transacción </returns>
        //[Authorize]
        [HttpDelete("DeleteProduct/{idProducto}")]
        public async Task<IActionResult> DeleteProduct(int idProducto)
        {
            var deleteProduct = await _productoServices.DeleteProduct(idProducto);
            return Ok(deleteProduct);
        }        

        /// <summary>
        /// Método para consultar todos los registros de los productos
        /// </summary>
        /// <returns>Lista con la información de los productos </returns>
        //[Authorize]
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult>GetAllProducts()
        {
            var getAllProducts = await _productoServices.GetAllProducts();            
            return Ok(getAllProducts);
        }

        /// <summary>
        /// Método para consultar la información de un usuario por su identificador
        /// </summary>
        /// <param name="idProducto"> Identificador del producto </param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("GetProductById/{idProducto}")]
        public async Task<IActionResult> GetProductById(int idProducto)
        {
            var getProductById = await _productoServices.GetProductById(idProducto);
            return Ok(getProductById);
        }
        #endregion Métodos

    }
}
