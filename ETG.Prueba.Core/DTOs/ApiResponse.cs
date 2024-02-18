#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Referencias

namespace ETG.Prueba.Core.DTOs
{
    public class ApiResponse<T>
    {
        #region Propiedades
        #region Públicas
        /// <summary>
        /// Código de la petición 
        /// </summary>
        public int Code { set; get; }

        /// <summary>
        /// Mensaje de la transacción
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// Propiedad generica de la clase para la información
        /// </summary>
        public T Data { get; set; }        
        #endregion públicas
        #endregion Propiedades

        #region Métodos
        #region Constructores
        /// <summary>
        /// Método constructor sobrecargado
        /// </summary>
        /// <param name="data"></param>
        public ApiResponse(T data)
        {
            this.Data = data;
        }

        public ApiResponse() 
        {
            this.Code = 400;
            this.Message = "Bad Request";            
        }        
        #endregion Constructor
        #endregion Métodos
    }
}
