#region Referencias
using AutoMapper;
using ETG.Prueba.Core.DTOs;
using ETG.Prueba.Core.Interfaces;
using ETG.Prueba.Core.Interfaces.Services;
using ETG.Prueba.Core.Static;
#endregion Referencias

namespace ETG.Prueba.Application.Services
{
    public class UsuariosServices : IUsuariosServices
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
        public UsuariosServices(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion Constructor

        /// <summary>
        /// Método para crear un usuario
        /// </summary>
        /// <param name="usuario"> Objeto con los datos del usuario </param>
        /// <returns></returns>
        /// <exception cref="Exceptions.UsuariosException"> Excepcion personalizada para creación de usuarios </exception>
        public async Task<ApiResponse<bool>> CreateUser(UsuariosDTO usuario)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {                
                var createUsuario = this.mapper.Map<Core.Entities.Usuarios>(usuario);
                createUsuario.UsuId = 0;
                await this.unitOfWork.UsuariosRepository.Add(createUsuario);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = UsuariosMessages.ERRUSU01;
                if (ex.GetType() == typeof(Exceptions.UsuariosException))
                    throw new Exceptions.UsuariosException(ex.Message);

                throw new Exceptions.UsuariosException(UsuariosMessages.ERRUSU01);
            }
            return response;
        }

        /// <summary>
        /// Método para actualizar un registro de usuario
        /// </summary>
        /// <param name="usuario"> Objeto de datos para actulizar </param>
        /// <returns></returns>
        /// <exception cref="Exceptions.UsuariosException"> Excepcion personalizada para actualización de usuarios </exception>
        public async Task<ApiResponse<bool>> UpdateUser(UsuariosDTO usuario)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {                
                var _usuario = await this.unitOfWork.UsuariosRepository.GetById(usuario.UsuID);
                _usuario.UsuPass = usuario.UsuPass;                
                this.unitOfWork.UsuariosRepository.Update(_usuario);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = UsuariosMessages.ERRUSU02;
                if (ex.GetType() == typeof(Exceptions.UsuariosException))
                    throw new Exceptions.UsuariosException(ex.Message);

                throw new Exceptions.UsuariosException(UsuariosMessages.ERRUSU02);
            }

            return response;
        }

        /// <summary>
        /// Método para realizar el borrado físico de un registro de usuarios   
        /// </summary>
        /// <param name="idUsuario"> Identificador del usuario </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"> Excepcion personalizada para actualización de usuarios </exception>
        public async Task<ApiResponse<bool>> DeleteUser(int idUsuario)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                var usuario = await this.unitOfWork.UsuariosRepository.Get(x => x.UsuId == idUsuario);
                if (usuario == null)
                {
                    throw new Exceptions.UsuariosException(UsuariosMessages.ERRUSU05);
                }

                var pedidosUsuario = await this.unitOfWork.PedidoRepository.GetAll(x => x.PedUsu == idUsuario);
                if (pedidosUsuario.Any())
                {
                    throw new Exceptions.UsuariosException(UsuariosMessages.ERRUSU03);
                }

                await this.unitOfWork.UsuariosRepository.Delete(idUsuario);
                await this.unitOfWork.SaveChangesAsync();
                response.Code = 200;
                response.Message = "Transacción realizada correctamente.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Message = UsuariosMessages.ERRUSU04;
                if (ex.GetType() == typeof(Exceptions.UsuariosException))
                    throw new Exceptions.UsuariosException(ex.Message);

                throw new Exceptions.UsuariosException(UsuariosMessages.ERRUSU04);
            }

            return response;
        }

        /// <summary>
        /// Método para consultar la información de todos los usuarios
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exceptions.UsuariosException"> Excepcion personalizada para consultar los usuarios </exception>
        public async Task<ApiResponse<List<UsuariosDTO>>> GetAllUsers()
        {
            ApiResponse<List<UsuariosDTO>> response = new ApiResponse<List<UsuariosDTO>>();
            try
            {
                var getAll = await this.unitOfWork.UsuariosRepository.GetAll();                
                response.Data = mapper.Map<List<UsuariosDTO>>(getAll);
                response.Code = 200;
                response.Message = "Consulta realizada correctamente.";

            }
            catch (Exception ex)
            {
                response.Message = UsuariosMessages.ERRUSU06;
                if (ex.GetType() == typeof(Exceptions.UsuariosException))
                    throw new Exceptions.UsuariosException(ex.Message);

                throw new Exceptions.UsuariosException(UsuariosMessages.ERRUSU06);                
            }

            return response;
        }

        /// <summary>
        /// Método para consultar la información de un usuario por su identificador
        /// </summary>
        /// <param name="idUsuario"> Identificador del usuario </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"> Excepcion personalizada para consultar  la información de un usuario </exception>
        public async Task<ApiResponse<UsuariosDTO>> GetUserById(int idUsuario)
        {
            ApiResponse<UsuariosDTO> response = new ApiResponse<UsuariosDTO>();
            try
            {
                var user = await this.unitOfWork.UsuariosRepository.GetById(idUsuario);
                response.Data = mapper.Map<UsuariosDTO>(user);
                response.Code = 200;
                response.Message = "Consulta realizada correctamente.";

            }
            catch (Exception ex)
            {
                response.Message = UsuariosMessages.ERRUSU07;
                if (ex.GetType() == typeof(Exceptions.UsuariosException))
                    throw new Exceptions.UsuariosException(ex.Message);

                throw new Exceptions.UsuariosException(UsuariosMessages.ERRUSU07);
            }

            return response;
        }        
        #endregion Públicos

        #endregion Métodos
    }
}
