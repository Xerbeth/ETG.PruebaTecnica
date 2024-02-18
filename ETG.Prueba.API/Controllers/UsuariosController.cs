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
    public class UsuariosController : ControllerBase
    {
        #region Propiedades
        #region Dependencias
        private readonly IUsuariosServices usuariosServices;
        #endregion Dependencias
        #endregion Propiedades

        #region Métodos 
        #region Constructor
        public UsuariosController(IUsuariosServices usuariosServices)
        {
            this.usuariosServices = usuariosServices;
        }
        #endregion Constructor        

        /// <summary>
        /// Método para consultar todos los registros de las areas
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult>GetAllUsers()
        {
            var getAllUsers = await usuariosServices.GetAllUsers();
            var response = new ApiResponse<List<UsuariosDTO>>(getAllUsers);
            return Ok(response);
        }
        #endregion Métodos

    }
}
