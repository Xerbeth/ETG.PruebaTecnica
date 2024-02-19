#region Referencias
using AutoMapper;
using ETG.Prueba.Core.DTOs;
using ETG.Prueba.Core.Entities;
using ETG.Prueba.Core.Interfaces;
using ETG.Prueba.Core.Interfaces.Services;
using ETG.Prueba.Core.Static;
#endregion Referencias

namespace ETG.Prueba.Application.Services
{
    public class ProductoServices : IProductoServices
    {
        #region Propiedades
        #region Dependencias
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        #endregion Dependencias
        #endregion Propiedades

        #region Métodos

        #region Públicos

        #region Constructor
        public ProductoServices(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion Constructor

        /// <summary>
        /// Método para registrar un producto
        /// </summary>
        /// <param name="producto"> Objeto con los datos del producto </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"> Excepcion personalizada para creación de productos </exception>
        public async Task<ApiResponse<bool>> CreateProduct(ProductoDTO producto)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                var createProducto = this.mapper.Map<Core.Entities.Producto>(producto);
                createProducto.ProId = 0;
                await this.unitOfWork.ProductoRepository.Add(createProducto);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ProductoMessages.ERRPRODC01;
                if (ex.GetType() == typeof(Exceptions.UsuariosException))
                    throw new Exceptions.UsuariosException(ex.Message);

                throw new Exceptions.UsuariosException(ProductoMessages.ERRPRODC01);
            }
            return response;
        }

        /// <summary>
        /// Método para actualizar un registro de producto
        /// </summary>        
        /// <param name="producto"> Objeto de datos para actulizar </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"> Excepcion personalizada para la actualización de productos </exception>
        public async Task<ApiResponse<bool>> UpdateProduct(ProductoDTO producto)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                var _producto = await this.unitOfWork.ProductoRepository.GetById(producto.ProID);
                _producto.ProDesc = producto.ProDesc;
                _producto.ProValor = producto.ProValor;
                this.unitOfWork.ProductoRepository.Update(_producto);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ProductoMessages.ERRPRODC02;
                if (ex.GetType() == typeof(Exceptions.ProductoException))
                    throw new Exceptions.ProductoException(ex.Message);

                throw new Exceptions.ProductoException(ProductoMessages.ERRPRODC02);
            }

            return response;
        }

        /// <summary>
        /// Método para realizar el borrado físico de un registro de producto   
        /// </summary>
        /// <param name="idProducto"> Identificador del producto </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"> Excepcion personalizada para la eliminación de productos </exception>
        public async Task<ApiResponse<bool>> DeleteProduct(int idProducto)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                var producto = await this.unitOfWork.ProductoRepository.Get(x => x.ProId == idProducto);
                if (producto == null)
                {
                    throw new Exceptions.ProductoException(ProductoMessages.ERRPRODC05);
                }

                var pedidosProducto = await this.unitOfWork.PedidoRepository.GetAll(x => x.PedProd == idProducto);
                if (pedidosProducto.Any())
                {
                    throw new Exceptions.ProductoException(ProductoMessages.ERRPRODC03);
                }

                await this.unitOfWork.ProductoRepository.Delete(idProducto);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = ProductoMessages.ERRPRODC04;
                if (ex.GetType() == typeof(Exceptions.ProductoException))
                    throw new Exceptions.ProductoException(ex.Message);

                throw new Exceptions.ProductoException(ProductoMessages.ERRPRODC04);
            }

            return response;
        }

        /// <summary>
        /// Método para consultar todos los registros de los productos
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"> Excepcion personalizada para la consulta de los productos </exception>
        public async Task<ApiResponse<List<ProductoDTO>>> GetAllProducts()
        {
            ApiResponse<List<ProductoDTO>> response = new ApiResponse<List<ProductoDTO>>();
            try
            {
                var getAll = await this.unitOfWork.ProductoRepository.GetAll();
                response.Data = mapper.Map<List<ProductoDTO>>(getAll);
                response.Code = 200;
                response.Message = "Consulta realizada correctamente.";

            }
            catch (Exception ex)
            {
                response.Message = ProductoMessages.ERRPRODC06;
                if (ex.GetType() == typeof(Exceptions.ProductoException))
                    throw new Exceptions.ProductoException(ex.Message);

                throw new Exceptions.ProductoException(ProductoMessages.ERRPRODC06);
            }

            return response;
        }

        /// <summary>
        /// Método para consultar la información de un usuario por su identificador
        /// </summary>
        /// <param name="idProducto"> Identificador del producto </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"> Excepcion personalizada para la consulta de los productos </exception>
        public async Task<ApiResponse<ProductoDTO>> GetProductById(int idProducto)
        {
            ApiResponse<ProductoDTO> response = new ApiResponse<ProductoDTO>();
            try
            {
                var product = await this.unitOfWork.ProductoRepository.GetById(idProducto);
                response.Data = mapper.Map<ProductoDTO>(product);
                response.Code = 200;
                response.Message = "Consulta realizada correctamente.";

            }
            catch (Exception ex)
            {
                response.Message = ProductoMessages.ERRPRODC07;
                if (ex.GetType() == typeof(Exceptions.ProductoException))
                    throw new Exceptions.ProductoException(ex.Message);

                throw new Exceptions.ProductoException(ProductoMessages.ERRPRODC07);
            }

            return response;
        }                

        #endregion Públicos

        #endregion Métodos
    }
}
