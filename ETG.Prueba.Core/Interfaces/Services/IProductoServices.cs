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
    public interface IProductoServices
    {
        Task<ApiResponse<bool>> CreateProduct(ProductoDTO producto);
        Task<ApiResponse<bool>> UpdateProduct(ProductoDTO producto);
        Task<ApiResponse<bool>> DeleteProduct(int idProducto);
        Task<ApiResponse<List<ProductoDTO>>> GetAllProducts();
        Task<ApiResponse<ProductoDTO>> GetProductById(int idProducto);
    }
}
