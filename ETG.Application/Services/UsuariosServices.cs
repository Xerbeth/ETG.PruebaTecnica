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
        /// Método para consultar la información de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<List<UsuariosDTO>> GetAllUsers()
        {
            try
            {
                var getAll = await this.unitOfWork.UsuariosRepository.GetAll();
                return mapper.Map<List<UsuariosDTO>>(getAll);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(Exceptions.UsuariosException))
                    throw new Exceptions.UsuariosException(ex.Message);

                throw new Exceptions.UsuariosException(UsuariosMessages.ERRUSU01);
            }
        }
        #endregion Públicos

        #endregion Métodos
    }
}
