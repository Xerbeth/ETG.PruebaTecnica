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
    public class PedidoServices : IPedidoServices
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
        public PedidoServices(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion Constructor

        /// <summary>
        /// Método para registrar un pedido
        /// </summary>
        /// <param name="pedido"> Objeto con los datos del pedido </param>
        /// <returns></returns>
        /// <exception cref="Exceptions.PedidoException"> Excepcion personalizada para creación de pedidos </exception>
        public async Task<ApiResponse<bool>> CreateOrder(PedidoDTO pedido)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                var createPedido = this.mapper.Map<Core.Entities.Pedido>(pedido);
                createPedido.PedId = 0;
                await this.unitOfWork.PedidoRepository.Add(createPedido);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = PedidoMessages.ERRPED01;
                if (ex.GetType() == typeof(Exceptions.PedidoException))
                    throw new Exceptions.PedidoException(ex.Message);

                throw new Exceptions.PedidoException(PedidoMessages.ERRPED01);
            }
            return response;
        }

        /// <summary>
        /// Método para actualizar un registro de pedido
        /// </summary>        
        /// <param name="pedido"> Objeto de datos para actualizar </param>
        /// <returns></returns>
        /// <exception cref="Exceptions.PedidoException"> Excepcion personalizada para la actualización de ordenes </exception>
        public async Task<ApiResponse<bool>> UpdateOrder(PedidoDTO pedido)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                var _pedido = await this.unitOfWork.PedidoRepository.GetById(pedido.PedID);
                _pedido.PedUsu = pedido.PedUsu;
                _pedido.PedProd = pedido.PedProd;
                _pedido.PedVrUnit = pedido.PedVrUnit;
                _pedido.PedCant = pedido.PedCant;
                _pedido.PedSubTot = pedido.PedSubTot;
                _pedido.PedIva = pedido.PedIVA;
                _pedido.PedTotal = pedido.PedTotal;                
                this.unitOfWork.PedidoRepository.Update(_pedido);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = PedidoMessages.ERRPED02;
                if (ex.GetType() == typeof(Exceptions.PedidoException))
                    throw new Exceptions.PedidoException(ex.Message);

                throw new Exceptions.PedidoException(PedidoMessages.ERRPED02);
            }

            return response;
        }

        /// <summary>
        /// Método para realizar el borrado físico de un registro de pedido   
        /// </summary>
        /// <param name="idPedido"> Identificador del pedido </param>
        /// <returns></returns>
        /// <exception cref="Exceptions.PedidoException"> Excepcion personalizada para la eliminacion de pedidos </exception>
        public async Task<ApiResponse<bool>> DeleteOrder(int idPedido)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                var pedido = await this.unitOfWork.PedidoRepository.Get(x => x.PedId == idPedido);
                if (pedido == null)
                {
                    throw new Exceptions.PedidoException(PedidoMessages.ERRPED05);
                }                

                await this.unitOfWork.PedidoRepository.Delete(idPedido);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = PedidoMessages.ERRPED04;
                if (ex.GetType() == typeof(Exceptions.PedidoException))
                    throw new Exceptions.PedidoException(ex.Message);

                throw new Exceptions.PedidoException(PedidoMessages.ERRPED04);
            }

            return response;
        }

        /// <summary>
        /// Método para consultar todos los registros de los pedidos
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exceptions.PedidoException"> Excepcion personalizada para la consulta de todos los pedidos </exception>
        public async Task<ApiResponse<List<PedidoDTO>>> GetAllOrderes()
        {
            ApiResponse<List<PedidoDTO>> response = new ApiResponse<List<PedidoDTO>>();
            try
            {
                var getAll = await this.unitOfWork.PedidoRepository.GetAll();
                response.Data = mapper.Map<List<PedidoDTO>>(getAll);
                response.Code = 200;
                response.Message = "Consulta realizada correctamente.";

            }
            catch (Exception ex)
            {
                response.Message = PedidoMessages.ERRPED06;
                if (ex.GetType() == typeof(Exceptions.PedidoException))
                    throw new Exceptions.PedidoException(ex.Message);

                throw new Exceptions.PedidoException(PedidoMessages.ERRPED06);
            }

            return response;
        }

        /// <summary>
        /// Método para consultar la información de un usuario por su identificador
        /// </summary>
        /// <param name="idPedido"> Identificador del pedido </param>
        /// <returns></returns>
        /// <exception cref="Exceptions.PedidoException"> Excepcion personalizada para la consulta de un pedido por identificador </exception>
        public async Task<ApiResponse<PedidoDTO>> GetOrderById(int idPedido)
        {
            ApiResponse<PedidoDTO> response = new ApiResponse<PedidoDTO>();
            try
            {
                var order = await this.unitOfWork.PedidoRepository.GetById(idPedido);
                response.Data = mapper.Map<PedidoDTO>(order);
                response.Code = 200;
                response.Message = "Consulta realizada correctamente.";

            }
            catch (Exception ex)
            {
                response.Message = PedidoMessages.ERRPED07;
                if (ex.GetType() == typeof(Exceptions.PedidoException))
                    throw new Exceptions.PedidoException(ex.Message);

                throw new Exceptions.PedidoException(PedidoMessages.ERRPED07);
            }

            return response;
        }        

        #endregion Públicos

        #endregion Métodos
    }
}
