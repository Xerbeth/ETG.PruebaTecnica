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
        /// Método para registrar un usuario
        /// </summary>
        /// <param name="usuario"> Objeto con los datos del usuario </param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UsuariosDTO usuario)
        {
            var createUser = await usuariosServices.CreateUser(usuario);
            return Ok(createUser);
        }

        /// <summary>
        /// Método para actualizar un registro de usuario
        /// </summary>        
        /// <param name="usuario"> Objeto de datos para actulizar </param>
        /// <returns> Resultado de la transacción </returns>
        //[Authorize]
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UsuariosDTO usuario)
        {
            var updateUser = await usuariosServices.UpdateUser(usuario);            
            return Ok(updateUser);
        }

        /// <summary>
        /// Método para realizar el borrado físico de un registro de usuarios   
        /// </summary>
        /// <param name="idUsuario"> Identificador del usuario </param>
        /// <returns> Resultado de la transacción </returns>
        //[Authorize]
        [HttpDelete("DeleteUser/{idUsuario}")]
        public async Task<IActionResult> DeleteArea(int idUsuario)
        {
            var deleteUser = await usuariosServices.DeleteUser(idUsuario);
            return Ok(deleteUser);
        }        

        /// <summary>
        /// Método para consultar todos los registros de los usuarios
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult>GetAllUsers()
        {
            var getAllUsers = await usuariosServices.GetAllUsers();            
            return Ok(getAllUsers);
        }

        /// <summary>
        /// Método para consultar la información de un usuario por su identificador
        /// </summary>
        /// <param name="idUsuario"> Identificador del usuario </param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("GetUserById/{idUsuario}")]
        public async Task<IActionResult> GetUserById(int idUsuario)
        {
            var getUserById = await usuariosServices.GetUserById(idUsuario);
            return Ok(getUserById);
        }
        #endregion Métodos

    }
}
