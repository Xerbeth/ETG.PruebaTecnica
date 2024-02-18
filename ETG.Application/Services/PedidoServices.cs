#region Referencias
using AutoMapper;
using ETG.Prueba.Core.Interfaces;
using ETG.Prueba.Core.Interfaces.Services;
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

        #endregion Públicos

        #endregion Métodos
    }
}
