#region Referencias
using ETG.Prueba.Core.DTOs;
#endregion Referencias

namespace ETG.Prueba.Core.Interfaces.Services
{
    public interface IUsuariosServices
    {
        Task<List<UsuariosDTO>> GetAllUsers();
    }
}
