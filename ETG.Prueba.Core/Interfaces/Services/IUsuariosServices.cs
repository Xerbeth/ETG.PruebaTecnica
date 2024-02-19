#region Referencias
using ETG.Prueba.Core.DTOs;
#endregion Referencias

namespace ETG.Prueba.Core.Interfaces.Services
{
    public interface IUsuariosServices
    {
        Task<ApiResponse<bool>> CreateUser(UsuariosDTO usuario);
        Task<ApiResponse<bool>> UpdateUser(UsuariosDTO usuario);
        Task<ApiResponse<bool>> DeleteUser(int idUsuario);         
        Task<ApiResponse<List<UsuariosDTO>>> GetAllUsers();
        Task<ApiResponse<UsuariosDTO>> GetUserById(int idUsuario);
    }
}
